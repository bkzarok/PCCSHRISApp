﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.HealthConditionArea.Controllers
{
    [Area("HealthConditionArea")]
    public class HealthConditionsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";

        public HealthConditionsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: HealthConditions
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.HealthConditions.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: HealthConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // GET: HealthConditions/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: HealthConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HaveAhealthCondition,IfYesExplain,DegreeOfHealthProblem,WhenStarted,MilitaryNo")] HealthCondition healthCondition)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(Battle),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                _context.Add(healthCondition);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = healthCondition.MilitaryNo });
            }
            ViewData["militaryNo"] = healthCondition.MilitaryNo;
            return View(healthCondition);
        }

        // GET: HealthConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = healthCondition.MilitaryNo;
            return View(healthCondition);
        }

        // POST: HealthConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HaveAhealthCondition,IfYesExplain,DegreeOfHealthProblem,WhenStarted,MilitaryNo")] HealthCondition healthCondition)
        {
            if (id != healthCondition.Id)
            {
                return NotFound();
            }
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(HealthCondition),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(log);
                    _context.Update(healthCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthConditionExists(healthCondition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = healthCondition.MilitaryNo });
            }
            ViewData["militaryNo"] = healthCondition.MilitaryNo;
            return View(healthCondition);
        }

        // GET: HealthConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCondition = await _context.HealthConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCondition == null)
            {
                return NotFound();
            }

            return View(healthCondition);
        }

        // POST: HealthConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(HealthCondition),
                CreatedOn = DateTime.UtcNow,
            };

            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition != null)
            {
                _context.Add(log);
                _context.HealthConditions.Remove(healthCondition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = healthCondition!.MilitaryNo });
        }

        private bool HealthConditionExists(int id)
        {
            return _context.HealthConditions.Any(e => e.Id == id);
        }
    }
}
