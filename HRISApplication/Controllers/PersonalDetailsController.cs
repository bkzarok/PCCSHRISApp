using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HRISApplication.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PersonalDetailsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";
              

        public PersonalDetailsController(SspdfContext context)
        {
            _context = context;
            
        }

        // GET: PersonalDetails
        public async Task<IActionResult> Index()
        {            
            return View(await _context.PersonalDetails.ToListAsync());
        }

        // GET: PersonalDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails                
                .FirstOrDefaultAsync(m => m.MilitaryNo== id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return View(personalDetail);
        }


        // GET: PersonalDetails/Details/5
        public async Task<IActionResult> DetailsAll(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails
                .Include(x => x.Children)
                .Include(x => x.Address)
                .Include(x => x.Schools)
                .Include(x => x.Languages)
                // .Include(x => x.Parents)
                .Include(x => x.Spouses)
                .Include(x => x.NextOfKins)
                .Include(x => x.Imprisonments)
                .Include(x => x.Enrollments)
                .Include(x => x.Training)
                .Include(x => x.Assignments)
                .Include(x => x.Battles)
                .Include(x => x.Promotions)
                .Include(x => x.HealthConditions)
                .Include(x => x.SalaryDetail)
                .FirstOrDefaultAsync(m => m.MilitaryNo == id);

            if (personalDetail == null)
            {
                return NotFound();
            }

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

            var log = new Log {
                UserName = User.Identity.Name,
                Action = CREATE_ACTION+" "+nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,               
            };

            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(string id, [Bind("MilitaryNo,SoldierRank,ProfilePicture,FormFile,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus")] PersonalDetail personalDetail)
        {
            if (id != personalDetail.MilitaryNo)
            {
                return NotFound();
            }
            var log = new Log
            {
                UserName = User.Identity.Name,
                Action = EDITED_ACTION + " "+nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
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
            var personalDetail = await _context.PersonalDetails
                 .Include(x => x.Children)
                .Include(x => x.Address)
                .Include(x => x.Schools)
                .Include(x => x.Languages)
                .Include(x => x.Parents)
                .Include(x => x.Spouses)
                .Include(x => x.NextOfKins)
                .Include(x => x.Imprisonments)
                .Include(x => x.Enrollments)
                .Include(x => x.Training)
                .Include(x => x.Assignments)
                .Include(x => x.Battles)
                .Include(x => x.Promotions)
                .Include(x => x.HealthConditions)
                .FirstOrDefaultAsync(x => x.MilitaryNo == id);

            var log = new Log
            {
                UserName = User.Identity.Name,
                Action = DELETED_ACTION + " " + nameof(PersonalDetail),
                CreatedOn = DateTime.UtcNow,
            };
            if (personalDetail != null)
            {               
                _context.Add(log);
                _context.PersonalDetails.Remove(personalDetail);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalDetailExists(string id)
        {
            return _context.PersonalDetails.Any(e => e.MilitaryNo == id);
        }
    }
}
