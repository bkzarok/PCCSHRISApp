using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.PersonalDetailsArea
{
    [Area("PersonalDetailsArea")]
    public class PersonalDetailsController : Controller
    {
        private readonly SspdfContext _context;

        public PersonalDetailsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: PersonalDetailsArea/PersonalDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalDetails.ToListAsync());
        }

        // GET: PersonalDetailsArea/PersonalDetails/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: PersonalDetailsArea/PersonalDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalDetailsArea/PersonalDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilitaryNo,ProfilePicture,SoldierRank,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalDetail);
        }

        // GET: PersonalDetailsArea/PersonalDetails/Edit/5
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

        // POST: PersonalDetailsArea/PersonalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MilitaryNo,ProfilePicture,SoldierRank,FirstName,MiddleName,LastName,DateOfBirth,BloodGroup,Ethnicity,ShieldNo,Gender,MaritalStatus,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] PersonalDetail personalDetail)
        {
            if (id != personalDetail.MilitaryNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

        // GET: PersonalDetailsArea/PersonalDetails/Delete/5
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

        // POST: PersonalDetailsArea/PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            if (personalDetail != null)
            {
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
