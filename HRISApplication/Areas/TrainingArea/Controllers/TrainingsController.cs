﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.TrainingArea.Controllers
{
    [Area("TrainingArea")]
    public class TrainingsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string EDITED_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "CREATED";

        public TrainingsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Training.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }


            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingType,TrainingCenter,Place,PeriodFrom,PeriodTo,MilitaryNo")] Training training)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(Training),
                CreatedOn = DateTime.UtcNow,
            };
            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = training.MilitaryNo });
            }
            ViewData["militaryNo"] = training.MilitaryNo;
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = training.MilitaryNo;
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainingType,TrainingCenter,Place,PeriodFrom,PeriodTo,MilitaryNo")] Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(Training),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(log);
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = training.MilitaryNo });
            }
            ViewData["militaryNo"] = training.MilitaryNo;
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = training.MilitaryNo;
            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = DELETED_ACTION + " " + nameof(Training),
                CreatedOn = DateTime.UtcNow,
            };
            var training = await _context.Training.FindAsync(id);
            if (training != null)
            {
                _context.Add(log);
                _context.Training.Remove(training);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = training!.MilitaryNo });
        }

        private bool TrainingExists(int id)
        {
            return _context.Training.Any(e => e.Id == id);
        }
    }
}
