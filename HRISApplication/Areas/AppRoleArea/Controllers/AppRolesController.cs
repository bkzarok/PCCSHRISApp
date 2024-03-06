using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRISApplication.Areas.AppRoleArea.Controllers
{
    [Area("AppRoleArea")]
    // [Authorize(Roles = "Admin, User")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            if (!_roleManager.RoleExistsAsync(identityRole.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(identityRole.Name)).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");
        }
    }
}
