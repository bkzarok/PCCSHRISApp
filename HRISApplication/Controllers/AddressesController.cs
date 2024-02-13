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
    public class AddressesController : Controller
    {
        private readonly SspdfContext _context;

        public AddressesController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Addresses
        //The parameter int Id is actually militaryNo value
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Addresses.Where(x => x.MilitaryNo == id);
            ViewData["MilitaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        //The parameter int Id is actually militaryNo value

        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Country,State,Counuty,Payam,Boma,MilitaryNo")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {Id = address.MilitaryNo});
            }
            ViewData["MilitaryNo"] = address.MilitaryNo;
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = address.MilitaryNo;
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,State,Counuty,Payam,Boma,MilitaryNo")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id = address.MilitaryNo});
            }
            ViewData["MilitaryNo"] = address.MilitaryNo;
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id =address!.MilitaryNo});
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
