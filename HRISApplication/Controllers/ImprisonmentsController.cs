using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Controllers
{
    public class ImprisonmentsController : Controller
    {
        private readonly SspdfContext _context;

        public ImprisonmentsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Imprisonments
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext= _context.Imprisonments.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Imprisonments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprisonment = await _context.Imprisonments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imprisonment == null)
            {
                return NotFound();
            }

            return View(imprisonment);
        }

        // GET: Imprisonments/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: Imprisonments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Imprisoned,Place,ForHowLong,Conviction,ExplainTheReason,MilitaryNo")] Imprisonment imprisonment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imprisonment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id=imprisonment.MilitaryNo});
            }
            ViewData["militaryNo"] = imprisonment.MilitaryNo;
            return View(imprisonment);
        }

        // GET: Imprisonments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprisonment = await _context.Imprisonments.FindAsync(id);
            if (imprisonment == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = imprisonment.MilitaryNo;
            return View(imprisonment);
        }

        // POST: Imprisonments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imprisoned,Place,ForHowLong,Conviction,ExplainTheReason,MilitaryNo")] Imprisonment imprisonment)
        {
            if (id != imprisonment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imprisonment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImprisonmentExists(imprisonment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id=imprisonment.MilitaryNo});
            }
            ViewData["militaryNo"] = imprisonment.MilitaryNo;
            return View(imprisonment);
        }

        // GET: Imprisonments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprisonment = await _context.Imprisonments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imprisonment == null)
            {
                return NotFound();
            }

            return View(imprisonment);
        }

        // POST: Imprisonments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imprisonment = await _context.Imprisonments.FindAsync(id);
            if (imprisonment != null)
            {
                _context.Imprisonments.Remove(imprisonment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id=imprisonment!.MilitaryNo});
        }

        private bool ImprisonmentExists(int id)
        {
            return _context.Imprisonments.Any(e => e.Id == id);
        }
    }
}
