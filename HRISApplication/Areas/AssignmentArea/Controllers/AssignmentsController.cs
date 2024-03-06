using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;
using System.Net;
using HRISApplication.Areas.AddressArea.Models;

namespace HRISApplication.Areas.AssignmentArea.Controllers
{
    [Area("AssignmentArea")]
    public class AssignmentsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";

        public AssignmentsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Assignments
        //The parameter int Id is actually militaryNo value
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Assignments.Where(x => x.MilitaryNo == id).Include(s => s.MilitaryNoNavigation);
            ViewData["MilitaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Assignments
                .Include(a => a.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Assignments/Create
        //The parameter int Id is actually militaryNo value
        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo")] Assignment assignment)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(Assignment),
                CreatedOn = DateTime.UtcNow,
            };
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = assignment.MilitaryNo });
            }
            ViewData["MilitaryNo"] = assignment.MilitaryNo;
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = assignment.MilitaryNo;
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(Assignment),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(log);
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Id = assignment.MilitaryNo }); 
            }
            ViewData["MilitaryNo"] = assignment.MilitaryNo;
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = DELETED_ACTION + " " + nameof(Assignment),
                CreatedOn = DateTime.UtcNow,
            };

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Add(log);
                _context.Assignments.Remove(assignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {Id=assignment!.MilitaryNo});
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
