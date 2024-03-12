using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using HRISApplication.Models.ChartModels;

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

        public async Task<IActionResult> PersonalCharts() {


            var soldierRankCount =
              from s in _context.PersonalDetails
              group s by s.SoldierRank into g
              select new WordCount { Word = g.Key, Count = g.Count() };

            var soldierBloodGroupCount =
               from s in _context.PersonalDetails
               group s by s.BloodGroup into g
               select new WordCount { Word =g.Key, Count = g.Count() };

            var soldierEthnicityCount =
               from s in _context.PersonalDetails
               group s by s.Gender into g
               select new WordCount { Word = g.Key ? "Male":"Female", Count = g.Count() };

            var ethnicitydCount =
              from s in _context.PersonalDetails
              group s by s.Ethnicity into g
              select new WordCount { Word = g.Key, Count = g.Count() };

            var soldierBirthDayCount =
               from s in _context.PersonalDetails
               group s by s.DateOfBirth into g
               select new WordCount { Word = g.Key.ToString(), Count = g.Count() };

            
            List<WordCount> newwordscount = new List<WordCount>();

            DateTime dateTime1989 = DateTime.Parse("01-01-1989");
            DateTime dateTime1984 = DateTime.Parse("01-01-1984");

            var date19891984 = new WordCount
            {
                Word = "1989-1984",
                Count = 0
            };

            DateTime dateTime1996 = DateTime.Parse("01-01-1996");
            DateTime dateTime1990 = DateTime.Parse("01-01-1990");

            var date19961990 = new WordCount
            {
                Word = "1996-1990",
                Count = 0
            };

            DateTime dateTime2001 = DateTime.Parse("01-01-2001");
            DateTime dateTime1997 = DateTime.Parse("01-01-1997");


            var date20011997= new WordCount
            {
                Word = "2001-1997",
                Count = 0
            };

            DateTime dateTime2002 = DateTime.Parse("01-01-2002");
            DateTime dateTime2005 = DateTime.Parse("01-01-2005");

            var date20022005 = new WordCount {
                Word = "2002-2005",
                Count = 0
            };

            foreach (var s in soldierBirthDayCount)
            {             
                DateTime dateTime = DateTime.Parse(s.Word);
                if (dateTime < dateTime2005 && dateTime > dateTime2002)
                {
                    date20022005.Count++;
                }

                if (dateTime < dateTime2001 && dateTime > dateTime1997)
                {
                    date20011997.Count++;
                }
                if (dateTime < dateTime1996 )
                {
                    date19961990.Count++;
                }
                if (dateTime < dateTime1989 && dateTime > dateTime1984)
                {
                    date20011997.Count++;
                }
                if (dateTime < dateTime1996)
                {
                    date19891984.Count++;
                }
            }

            newwordscount.Add(date20022005);
            newwordscount.Add(date20011997);
            newwordscount.Add(date19961990);
            newwordscount.Add(date19891984);

            var mycharts = new Tuple<IEnumerable<WordCount>, IEnumerable<WordCount>,
                IEnumerable<WordCount>, IEnumerable<WordCount>>(
                soldierRankCount.ToList(),
                soldierBloodGroupCount.ToList(),
                //soldierGenderCount.ToList(),
                soldierEthnicityCount.ToList(),
                newwordscount);

            return View(mycharts);
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
            else
            {
                var file = System.IO.File.ReadAllBytes("~/logo.png");
                personalDetail.ProfilePicture = file.ToArray();
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

            var sm = new MemoryStream(personalDetail.ProfilePicture);
            personalDetail.FormFile = new FormFile(sm, 0, personalDetail.ProfilePicture.Length, "FormFile", "TempFileName");

          //personalDetail.ProfilePicture;
            return View(personalDetail);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MilitaryNo,SoldierRank,ProfilePicture,FormFile,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus," +
            "CreatedBy,CreatedOn, ModifiedBy, ModifiedOn")] PersonalDetail personalDetail)
        {
            if (id != personalDetail.MilitaryNo)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalDetail = await _context.PersonalDetails.FirstOrDefaultAsync(x => x.MilitaryNo == id);


            var log = new Log
            {
                UserName = User.Identity.Name,
                Action = DELETED_ACTION + " " + nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };
            if (personalDetail != null)
            {
               personalDetail = await PersonalDetailIncludeAll(personalDetail, id);
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
