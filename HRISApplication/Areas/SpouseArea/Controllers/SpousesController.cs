using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.SpouseArea.Controllers
{
    [Area("SpouseArea")]
    public class SpousesController : Controller
    {
        private readonly SspdfContext _context;

        public SpousesController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Spouses
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Spouses.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Spouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spouse = await _context.Spouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spouse == null)
            {
                return NotFound();
            }


            return View(spouse);
        }

        // GET: Spouses/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: Spouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,State,County,Occupation,TelephoneNo,MilitaryNo")] Spouse spouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = spouse.MilitaryNo });
            }
            ViewData["militaryNo"] = spouse.MilitaryNo;
            return View(spouse);
        }

        // GET: Spouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spouse = await _context.Spouses.FindAsync(id);
            if (spouse == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = spouse.MilitaryNo;
            return View(spouse);
        }

        // POST: Spouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Type,State,County,Occupation,TelephoneNo,MilitaryNo")] Spouse spouse)
        {
            if (id != spouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpouseExists(spouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = spouse.MilitaryNo });
            }
            ViewData["militaryNo"] = spouse.MilitaryNo;
            return View(spouse);
        }

        // GET: Spouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spouse = await _context.Spouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spouse == null)
            {
                return NotFound();
            }

            return View(spouse);
        }

        // POST: Spouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spouse = await _context.Spouses.FindAsync(id);
            if (spouse != null)
            {
                _context.Spouses.Remove(spouse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = spouse!.MilitaryNo });
        }

        private bool SpouseExists(int id)
        {
            return _context.Spouses.Any(e => e.Id == id);
        }
    }
}
