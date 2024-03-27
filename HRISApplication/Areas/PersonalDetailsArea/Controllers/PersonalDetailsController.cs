using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using HRISApplication.Models.ChartModels;
using static NuGet.Packaging.PackagingConstants;

namespace HRISApplication.Areas.Controllers
{
    [Area("PersonalDetailsArea")]
    [Authorize(Roles = "Admin, User")]
    public class PersonalDetailsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";
        private readonly object soldierGenderCount;
        private IWebHostEnvironment _env;

        public PersonalDetailsController(SspdfContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;            
        }

        // GET: PersonalDetails
        public async Task<IActionResult> Index()
        {            
            //return View(await _context.PersonalDetails.ToListAsync());
           return View(new List<PersonalDetail>());
        }

        [HttpPost]
        public JsonResult GetPersonalDetails()
        {
            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var data = _context.Set<PersonalDetail>().AsQueryable();
            //get total count of data in table
            totalRecord = data.Count();
            // search data when search value found
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.FirstName.ToLower().Contains(searchValue.ToLower())
                || x.MiddleName.ToLower().Contains(searchValue.ToLower()) ||
                x.LastName.ToLower().Contains(searchValue.ToLower()) ||
                x.SoldierRank.ToString().ToLower().Contains(searchValue.ToLower()));
            }
            // get total count of records after search
            filterRecord = data.Count();
            //sort data
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
            {
                if(sortColumnDirection.Equals("asc"))
                    data = PersonalDetailOrderByASC(data, sortColumn);

                data = PersonalDetailOrderByDESC(data, sortColumn);                
            }
                
            //pagination
            var empList = data.Skip(skip).Take(pageSize).ToList();
            var returnObj = new
            {
                draw = draw,
                recordsTotal = totalRecord,
                recordsFiltered = filterRecord,
                data = empList
            };
            return Json(returnObj);
        }

        // GET: PersonalDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return View(personalDetail);
        }
        
        //GET: PersonalDetails/RankChart
        public async Task<IActionResult> BloodGroupChart()
        {
            var soldierBloodGroupCount =
               from s in _context.PersonalDetails
               group s by s.BloodGroup into g
               select new WordCount { Word = g.Key, Count = g.Count() };

            return View(await soldierBloodGroupCount.ToListAsync());
        }

        //GET: PersonalDetails/PersonalReportsRank
        public async Task<IActionResult> PersonalReportsRank()
        {
            var assignments = _context.Assignments.Include(m => m.MilitaryNoNavigation).ToList();


            var unitMiliNo = from s in assignments
                             group s by s.Unit into unitG
                             select new WordWordCount {
                                 Word = unitG.First().Unit,
                                 WordCount = unitG.GroupBy(x => x.MilitaryNoNavigation.SoldierRank)
                                 .Select(g => new
                                 WordCount
                                 {
                                     Word = g.Key,
                                     Count = g.Count()
                                 }).OrderBy(x => x.Word).ToList()
                             };
           
            return View(unitMiliNo);
        }

        //GET: PersonalDetails/PersonalReportsRank
        public async Task<IActionResult> PersonalReportsBloodGroup()
        {
          var assignments = _context.Assignments.Include(m => m.MilitaryNoNavigation).ToList();


            var unitMiliNo = from s in assignments
                             group s by s.Unit into unitG
                             select new WordWordCount
                             {
                                 Word = unitG.First().Unit,
                                 WordCount = unitG.GroupBy(x => x.MilitaryNoNavigation.BloodGroup)
                                 .Select(g => new
                                 WordCount
                                 {
                                     Word = g.Key,
                                     Count = g.Count()
                                 }).OrderBy(x => x.Word).ToList()
                             };

            return View(unitMiliNo);
        }

        //GET: PersonalDetails/RankChart
        public async Task<IActionResult> RankChart()
        {
            var rankCount =
               from s in _context.PersonalDetails
               group s by s.SoldierRank into g
               select new WordCount { Word = g.Key, Count = g.Count() };

            return View(await rankCount.ToListAsync());
        }

        // GET: PersonalDetails/Details/5
        public async Task<IActionResult> DetailsAll(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails.FirstOrDefaultAsync(x => x.MilitaryNo == id);
           
            if (personalDetail == null)
            {
                return NotFound();
            }
            personalDetail = await PersonalDetailIncludeAll(personalDetail, id);

            return View(personalDetail);
        }

        [Authorize(Roles = "Admin")]
        // GET: PersonalDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilitaryNo,SoldierRank,FormFile,ProfilePicture,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus")] PersonalDetail personalDetail)
        {
            //Assign the profilepicture to a byte array
            if (personalDetail.FormFile != null)
            {
                var ms = new MemoryStream();
                personalDetail.FormFile.CopyTo(ms);
                personalDetail.ProfilePicture = ms.ToArray();
            }            

            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                personalDetail.CreatedBy = User.Identity != null ? User.Identity.Name : "NoUser";
                personalDetail.CreatedOn = DateTime.UtcNow;
                _context.Add(personalDetail);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalDetail);
        }

       
        [Authorize(Roles = "Admin")]
        // GET: PersonalDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

   
            return View(personalDetail);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string MilitaryNo, [Bind("MilitaryNo,SoldierRank,ProfilePicture,FormFile,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus," +
            "CreatedBy,CreatedOn, ModifiedBy, ModifiedOn")] PersonalDetail personalDetail)
        {

            if (MilitaryNo != personalDetail.MilitaryNo)
            {
                return NotFound();
            }

            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " "+nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                personalDetail.ModifiedBy = User.Identity != null ? User.Identity.Name : "NoUser"; 
                personalDetail.ModifiedOn = DateTime.UtcNow;

                //Assign the profilepicture to a byte array
                if (personalDetail.FormFile != null)
                {
                    var ms = new MemoryStream();
                    personalDetail.FormFile.CopyTo(ms);
                    personalDetail.ProfilePicture = ms.ToArray();
                }               

                try
                {
                    _context.Add(log);
                    _context.Update(personalDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalDetailExists(personalDetail.MilitaryNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personalDetail);
        }

        [Authorize(Roles = "Admin")]
        // GET: PersonalDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails
                .FirstOrDefaultAsync(m => m.MilitaryNo == id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return View(personalDetail);
        }

        [Authorize(Roles = "Admin")]
        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string MilitaryNo)
        {
            var personalDetail = await _context.PersonalDetails.FirstOrDefaultAsync(x => x.MilitaryNo == MilitaryNo);

            var log = new Log
            {
                UserName = User.Identity.Name,
                Action = DELETED_ACTION + " " + nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };
            if (personalDetail != null)
            {
               personalDetail = await PersonalDetailIncludeAll(personalDetail, MilitaryNo);
                _context.Add(log);
                _context.PersonalDetails.Remove(personalDetail);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


       private IQueryable<PersonalDetail> PersonalDetailOrderByASC(IQueryable<PersonalDetail> query, string orderColumn)
        {
            switch(orderColumn)
            {
                case "MilitaryNo":
                    return query.OrderBy(q => q.MilitaryNo);
                case "SoldierRank":
                    return query.OrderBy(q => q.SoldierRank);
                case "FirstName":

                    return query.OrderBy(q => q.FirstName);
                case "MiddleName":

                    return query.OrderBy(q => q.MiddleName);
                case "LastName":

                    return query.OrderBy(q => q.LastName);
                case "DateOfBirth":

                    return query.OrderBy(q => q.DateOfBirth);
                case "ShieldNo":

                    return query.OrderBy(q => q.ShieldNo);
                case "Gender":

                    return query.OrderBy(q => q.Gender);
                default : return query.OrderBy(q => q.FirstName);
            }
        }

        private IQueryable<PersonalDetail> PersonalDetailOrderByDESC(IQueryable<PersonalDetail> query, string orderColumn)
        {
            switch (orderColumn)
            {
                case "MilitaryNo":
                    return query.OrderByDescending(q => q.MilitaryNo);
                case "SoldierRank":
                    return query.OrderByDescending(q => q.SoldierRank);
                case "FirstName":

                    return query.OrderByDescending(q => q.FirstName);
                case "MiddleName":

                    return query.OrderByDescending(q => q.MiddleName);
                case "LastName":

                    return query.OrderByDescending(q => q.LastName);
                case "DateOfBirth":

                    return query.OrderByDescending(q => q.DateOfBirth);
                case "ShieldNo":

                    return query.OrderByDescending(q => q.ShieldNo);
                case "Gender":

                    return query.OrderByDescending(q => q.Gender);
                default: return query.OrderByDescending(q => q.FirstName);
            }
        }

        private async Task<PersonalDetail> PersonalDetailIncludeAll(PersonalDetail personalDetail, string id)
        {
            personalDetail.Children = await _context.Children.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Address = await _context.Addresses.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Schools = await _context.Schools.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Languages = await _context.Languages.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Parents = await _context.Parents.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Spouses = await _context.Spouses.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.NextOfKins = await _context.NextOfKins.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Imprisonments = await _context.Imprisonments.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Enrollments = await _context.Enrollments.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Training = await _context.Training.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Assignments = await _context.Assignments.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Battles = await _context.Battles.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.Promotions = await _context.Promotions.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.HealthConditions = await _context.HealthConditions.Where(x => x.MilitaryNo == id).ToListAsync();
            personalDetail.SalaryDetail = await _context.SalaryDetails.Where(x => x.MilitaryNo == id).ToListAsync();

            return personalDetail;
        }






        // A recursive function that searches for a property in an object and sets it to null
        public static void SetPropertyToNull(object obj, string propertyName)
        {
            // Check if the object is null or not
            if (obj == null  ) return;

            
            // Get the type of the object
            Type objType = obj.GetType();
            objType = objType.IsArray ? objType.GetElementType() : objType; 

            if (IsSimpleType(objType)) return;

            // Get the properties of the type
            PropertyInfo[] properties = objType.GetProperties();

            // Loop through the properties
            foreach (PropertyInfo property in properties)
            {
                // Get the name and value of the property
                string name = property.Name;

                object value;
                try
                {
                    value = property.GetValue(obj);

                }
                catch (Exception)
                {

                    return;
                }
                    
              
                // Check if the name matches the property name
                if (name == propertyName)
                {
                    // Set the value to null
                    property.SetValue(obj, null);
                }
                else
                {
                    // Call the function recursively on the value
                    SetPropertyToNull(value, propertyName);
                }
            }

            //// Get the fields of the type
            //FieldInfo[] fields = objType.GetFields();

            //// Loop through the fields
            //foreach (FieldInfo field in fields)
            //{
            //    // Get the name and value of the field
            //    string name = field.Name;
            //    object value = field.GetValue(obj);

            //    // Check if the name matches the property name
            //    if (name == propertyName)
            //    {
            //        // Set the value to null
            //        field.SetValue(obj, null);
            //    }
            //    else
            //    {
            //        // Call the function recursively on the value
            //        SetPropertyToNull(value, propertyName);
            //    }
            //}
        }

        public static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(string),
            typeof(decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                type.IsEnum ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }

        private bool PersonalDetailExists(string id)
        {
            return _context.PersonalDetails.Any(e => e.MilitaryNo == id);
        }
    }
}
