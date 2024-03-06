using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.BattleArea.Controllers
{
    [Area("BattleArea")]
    public class BattlesController : Controller
    {
        private readonly SspdfContext _context;

        public BattlesController(SspdfContext context)
        {
            _context = context;
        }

        // GET: Battles
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.Battles.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: Battles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battle = await _context.Battles

             .FirstOrDefaultAsync(m => m.Id == id);
            if (battle == null)
            {
                return NotFound();
            }

            return View(battle);
        }

        // GET: Battles/Create
        public IActionResult Create(string id)
        {
            ViewData["militaryNo"] = id;
            return View();
        }

        // POST: Battles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfBattle,PlaceOfBattle,InjurySustained,TypeOfInjury,MilitaryNo")] Battle battle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(battle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = battle.MilitaryNo });
            }
            ViewData["militaryNo"] = battle.MilitaryNo;
            return View(battle);
        }

        // GET: Battles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battle = await _context.Battles.FindAsync(id);
            if (battle == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = battle.MilitaryNo;
            return View(battle);
        }

        // POST: Battles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfBattle,PlaceOfBattle,InjurySustained,TypeOfInjury,MilitaryNo")] Battle battle)
        {
            if (id != battle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(battle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BattleExists(battle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = battle.MilitaryNo });
            }
            return View(battle);
        }

        // GET: Battles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battle = await _context.Battles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (battle == null)
            {
                return NotFound();
            }
            ViewData["militaryNo"] = battle.MilitaryNo;
            return View(battle);
        }

        // POST: Battles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var battle = await _context.Battles.FindAsync(id);
            if (battle != null)
            {
                _context.Battles.Remove(battle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = battle!.MilitaryNo });
        }

        private bool BattleExists(int id)
        {
            return _context.Battles.Any(e => e.Id == id);
        }
    }
}
