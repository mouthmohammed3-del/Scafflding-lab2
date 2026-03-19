using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Scaffoldinglab2.Controllers
{
   
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()

        {
            var roles = await roleManager.Roles.ToListAsync();

            return View(roles);
        }
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return View();
            }
            var role = new IdentityRole { Name = name };
            var res = await roleManager.CreateAsync(role);
            if(res.Succeeded)
            {
                return View("Index");
            }
            return View(model:name);
        }
    }
}
