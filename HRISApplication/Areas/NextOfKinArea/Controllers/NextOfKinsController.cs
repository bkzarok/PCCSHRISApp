using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.NextOfKinArea.Controllers
{
   [Area("NextOfKinArea")]
    public class NextOfKinsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";

        public NextOfKinsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: NextOfKins
        //The parameter int Id is actually militaryNo value
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.NextOfKins.Where(x => x.MilitaryNo == id);
            ViewData["MilitaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: NextOfKins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins
                .Include(n => n.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // GET: NextOfKins/Create
        //The parameter int Id is actually militaryNo value
        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }

        // POST: NextOfKins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Occupation,TelephoneNo,MilitaryNo")] NextOfKin nextOfKin)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(NextOfKin),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                _context.Add(nextOfKin);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = nextOfKin.MilitaryNo });
            }
            ViewData["MilitaryNo"] = nextOfKin.MilitaryNo;
            return View(nextOfKin);
        }

        // GET: NextOfKins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins.FindAsync(id);
            if (nextOfKin == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = nextOfKin.MilitaryNo;
            return View(nextOfKin);
        }

        // POST: NextOfKins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Occupation,TelephoneNo,MilitaryNo")] NextOfKin nextOfKin)
        {
            if (id != nextOfKin.Id)
            {
                return NotFound();
            }
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(Language),
                CreatedOn = DateTime.UtcNow,
            };


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(log);
                    _context.Update(nextOfKin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NextOfKinExists(nextOfKin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = nextOfKin.MilitaryNo });
            }
            ViewData["MilitaryNo"] = nextOfKin.MilitaryNo;
            return View(nextOfKin);
        }

        // GET: NextOfKins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins
                .Include(n => n.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // POST: NextOfKins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = DELETED_ACTION + " " + nameof(NextOfKin),
                CreatedOn = DateTime.UtcNow,
            };

            var nextOfKin = await _context.NextOfKins.FindAsync(id);
            if (nextOfKin != null)
            {
                _context.Add(log);
                _context.NextOfKins.Remove(nextOfKin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = nextOfKin!.MilitaryNo });
        }

        private bool NextOfKinExists(int id)
        {
            return _context.NextOfKins.Any(e => e.Id == id);
        }
    }
}
