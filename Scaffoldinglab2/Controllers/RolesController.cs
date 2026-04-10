using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.ViewModels;

namespace Scaffoldinglab2.Controllers
{
   
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<SysUser> userManger;

        public RolesController(RoleManager<IdentityRole> roleManager,UserManager<SysUser> userManger)
        {
            this.roleManager = roleManager;
            this.userManger = userManger;
        }
        public async Task<IActionResult> Index()

        {
            var roles = await roleManager.Roles.ToListAsync();

            return View(roles);
        }

        public async Task<IActionResult> Manage(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                TempData["error"] = "Enter user id";
                return RedirectToAction("Index","Account");
            }
            var user = await userManger.FindByIdAsync(userid);
            if (user == null)
            {
                TempData["error"] = "No user found with this Id ";

                return RedirectToAction("Index", "Account");
            }
            var userRoles = new UserRolesVM
            {

                UserId = user.Id,

                FullName = user.FullName,

                UserName = user.UserName,

            };
            var allRoles = await roleManager.Roles.ToListAsync();
            var rolesList = new List<RoleVM>();

            foreach (var role in allRoles)
            {
                if( await userManger.IsInRoleAsync(user, role.Name))
                {
                    rolesList.Add(new RoleVM
                    {
                        Name = role.Name,
                        Id = role.Id,
                        Checked = true

                    });
                }
                else
                {
                    rolesList.Add(new RoleVM
                    {
                        Name = role.Name,
                        Id = role.Id,
                        Checked = false

                    }) ;
                }
            }
            userRoles.Roles = rolesList;
            return View(userRoles);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(UserRolesVM userRoles)
        {
            if (userRoles == null)
            {
                TempData["error"] = "Please Enter all data";
                return View();
            }
            var user = await userManger.FindByIdAsync(userRoles.UserId);
            var del =  await userManger.RemoveFromRolesAsync(user,userRoles.Roles.Select(s=>s.Name));
            if (del.Succeeded)
            {
                var checkedlist = userRoles.Roles.Where(s=>s.Checked==true).ToList();
                var addToRole = await userManger.AddToRolesAsync(user,checkedlist.Select(s=>s.Name));
            }

            return RedirectToAction("Index", "Account");

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
                return RedirectToAction("Index");
            }
            return View(model:name);
        }
    }
}
