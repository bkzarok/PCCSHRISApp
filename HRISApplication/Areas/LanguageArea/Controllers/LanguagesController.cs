﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.LanguageArea.Controllers
{
    [Area("LanguageArea")]
    public class LanguagesController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string EDITED_ACTION = "EDITED";
        private static readonly string DELETED_ACTION = "DELETED";

        public LanguagesController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Languages
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Languages.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Name,FluencyLevel,MilitaryNo")] Language language)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(Language),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                _context.Add(language);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = language.MilitaryNo });
            }
            ViewData["language"] = language.MilitaryNo;
            return View(language);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = language.MilitaryNo;
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Name,FluencyLevel,MilitaryNo")] Language language)
        {
            if (id != language.Id)
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
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = language.MilitaryNo });
            }
            ViewData["militaryNo"] = language.MilitaryNo;
            return View(language);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = DELETED_ACTION + " " + nameof(Language),
                CreatedOn = DateTime.UtcNow,
            };

            var language = await _context.Languages.FindAsync(id);
            if (language != null)
            {
                _context.Add(log);
                _context.Languages.Remove(language);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = language!.MilitaryNo });
        }

        private bool LanguageExists(int id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
