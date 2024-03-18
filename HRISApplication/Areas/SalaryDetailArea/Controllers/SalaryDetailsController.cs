﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace HRISApplication.Areas.SalaryDetailArea.Controllers
{
    [Area("SalaryDetailArea")]
    public class SalaryDetailsController : Controller
    {
        private readonly SspdfContext _context;
        private static readonly string CREATE_ACTION = "CREATED";
        private static readonly string DELETED_ACTION = "DELETED";
        private static readonly string EDITED_ACTION = "EDITED";

        public SalaryDetailsController(SspdfContext context)
        {
            _context = context;
        }

        // GET: SalaryDetails
        public async Task<IActionResult> Index(string id)
        {
            IIncludableQueryable<SalaryDetail, PersonalDetail> sspdfContext;

            if (string.IsNullOrEmpty(id))
            {
                sspdfContext = _context.SalaryDetails.Include(s => s.MilitaryNoNavigation);
                ViewData["MilitaryNo"] = null;
            }
            else
            {
                sspdfContext = _context.SalaryDetails.Where(x => x.MilitaryNo == id).Include(s => s.MilitaryNoNavigation);
                ViewData["MilitaryNo"] = id;
            }
            return View(await sspdfContext.ToListAsync());

        }

        // GET: SalaryDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails
                .Include(s => s.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            return View(salaryDetail);
        }

        // GET: SalaryDetails/Create
        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }

        // POST: SalaryDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Grade,BasicPay,Cola,ResponsibiltyAllowance,RepresentationAllowance,HouseAllowance,GrossTotal,Pit,Pension,TotalDeduction,NetPay,MilitaryNo")] SalaryDetail salaryDetail)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = CREATE_ACTION + " " + nameof(SalaryDetail),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                _context.Add(salaryDetail);
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = salaryDetail.MilitaryNo });
            }
            ViewData["MilitaryNo"] = salaryDetail.MilitaryNo;
            return View(salaryDetail);
        }

        // GET: SalaryDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails.FindAsync(id);
            if (salaryDetail == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = salaryDetail.MilitaryNo; //new SelectList(_context.PersonalDetails, "MilitaryNo", "MilitaryNo", salaryDetail.MilitaryNo);
            return View(salaryDetail);
        }

        // POST: SalaryDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade,BasicPay,Cola,ResponsibiltyAllowance,RepresentationAllowance,HouseAllowance,GrossTotal,Pit,Pension,TotalDeduction,NetPay,MilitaryNo")] SalaryDetail salaryDetail)
        {
            if (id != salaryDetail.Id)
            {
                return NotFound();
            }
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = EDITED_ACTION + " " + nameof(SalaryDetail),
                CreatedOn = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(log);
                    _context.Update(salaryDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryDetailExists(salaryDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MilitaryNo"] = salaryDetail.MilitaryNo;
            return View(salaryDetail);
        }

        // GET: SalaryDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails
                .Include(s => s.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            return View(salaryDetail);
        }

        // POST: SalaryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = new Log
            {
                UserName = User.Identity != null ? User.Identity.Name : "NoUser",
                Action = DELETED_ACTION + " " + nameof(SalaryDetail),
                CreatedOn = DateTime.UtcNow,
            };
            var salaryDetail = await _context.SalaryDetails.FindAsync(id);
            if (salaryDetail != null)
            {
                _context.Add(log);
                _context.SalaryDetails.Remove(salaryDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryDetailExists(int id)
        {
            return _context.SalaryDetails.Any(e => e.Id == id);
        }
    }
}
