using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Data;
using HRISApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HRISApplication.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class RoleAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleAssignmentsController(ApplicationDbContext context, IUserStore<IdentityUser> userStore, 
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userStore = userStore;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: RoleAssignments
        public async Task<IActionResult> Index()
        {
            var userNamesAndRoles = await _context.Users
                .Join(_context.UserRoles, 
                u => u.Id,
                ur => ur.UserId,
                (u, ur) => new {u.Id, u.UserName, ur.RoleId})
                .Join( _context.Roles,
                uur => uur.RoleId,
                r => r.Id,
                (uur, r) => new RoleAssignment { Id = uur.Id, UserName = uur.UserName, RoleId = uur.RoleId, Name = r.Name })
                .ToListAsync();

            return View(userNamesAndRoles);
        }

        // GET: RoleAssignments/Details/5
        public async Task<IActionResult> Details(string? id, string? roleId)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var roleAssignment = await _context.Users
               .Join(_context.UserRoles,
               u => u.Id,
               ur => ur.UserId,
               (u, ur) => new { u.Id, u.UserName, ur.RoleId })
               .Join(_context.Roles,
               uur => uur.RoleId,
               r => r.Id,
               (uur, r) => new RoleAssignment { Id = uur.Id, UserName = uur.UserName, RoleId = uur.RoleId, Name = r.Name })
               .FirstOrDefaultAsync( ra => ra.Id.Equals(id) && ra.RoleId.Equals(roleId));

            if (roleAssignment == null)
            {
                return NotFound();
            }

            return View(roleAssignment);
        }

        // GET: RoleAssignments/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.Roles, "Name", "Name");
            ViewData["UserName"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }



        // POST: RoleAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] RoleAssignment roleAssignment)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == roleAssignment.Id);    

            if (ModelState.IsValid && user != null)
            {
                if(!await _userManager.IsInRoleAsync(user, roleAssignment.Name))
                {
                    await _userManager.AddToRoleAsync(user, roleAssignment.Name);
                }
             
                return RedirectToAction(nameof(Index));
            }
            return View(roleAssignment);
        }

        // GET: RoleAssignments/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? id, string? roleId)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var roleAssignment = await _context.Users
               .Join(_context.UserRoles,
                   u => u.Id,
                   ur => ur.UserId,
                   (u, ur) => new { u.Id, u.UserName, ur.RoleId })
               .Join(_context.Roles,
                   uur => uur.RoleId,
                   r => r.Id,
                   (uur, r) => new RoleAssignment { Id = uur.Id, UserName = uur.UserName, RoleId = uur.RoleId, Name = r.Name })
               .FirstOrDefaultAsync(ra => ra.Id.Equals(id) && ra.RoleId.Equals(roleId));

            if (roleAssignment == null)
            {
                return NotFound();
            }

            return View(roleAssignment);
        }

        // POST: RoleAssignments/Delete/5
        [Authorize(Roles ="Admin, User")]   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string name)
        {

            if (_context.UserRoles == null)
            {
                return Problem("Entity set ' pccsdbContext.Roleassignemtn' in null.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, name);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //// GET: RoleAssignments/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleAssignment = await _context.RoleAssignment.FindAsync(id);
        //    if (roleAssignment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(roleAssignment);
        //}

        //// POST: RoleAssignments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("RoleId,Name,Id,UserName")] RoleAssignment roleAssignment)
        //{
        //    if (id != roleAssignment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(roleAssignment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoleAssignmentExists(roleAssignment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(roleAssignment);
        //}


        //private bool RoleAssignmentExists(string id)
        //{
        //    return _context.RoleAssignment.Any(e => e.Id == id);
        //}
    }
}
