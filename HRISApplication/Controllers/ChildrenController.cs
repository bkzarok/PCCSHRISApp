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
    public class ChildrenController : Controller
    {
        private readonly SspdfContext _context;

        public ChildrenController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Children
        //The parameter int Id is actually militaryNo value
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Children.Where(x => x.MilitaryNo == id);
            ViewData["MilitaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Children/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Children
                .Include(c => c.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // GET: Children/Create
        //The parameter int Id is actually militaryNo value
        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateOfBirth,Occupation,MilitaryNo")] Child child)
        {
            if (ModelState.IsValid)
            {
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id=child.MilitaryNo});
            }
            ViewData["MilitaryNo"] = child.MilitaryNo;
            return View(child);
        }

        // GET: Children/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Children.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = child.MilitaryNo;
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth,Occupation,MilitaryNo")] Child child)
        {
            if (id != child.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(child.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id=child.MilitaryNo});
            }
            ViewData["MilitaryNo"] = child.MilitaryNo;
            return View(child);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Children
                .Include(c => c.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child != null)
            {
                _context.Children.Remove(child);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id=child!.MilitaryNo});
        }

        private bool ChildExists(int? id)
        {
            return _context.Children.Any(e => e.Id == id);
        }
    }
}
