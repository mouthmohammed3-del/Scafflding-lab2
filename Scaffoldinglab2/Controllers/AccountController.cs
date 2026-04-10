using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.ViewModels;

namespace Scaffoldinglab2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<SysUser> userManager;
        private readonly SignInManager<SysUser> signInManager;

        public AccountController( UserManager<SysUser> userManager , SignInManager<SysUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {

            var users = await userManager.Users.ToListAsync();
            List<UserVM> usersVMs = new List<UserVM>();
            foreach(var u in users)
            {

                usersVMs.Add(new UserVM
                {
                    Id = u.Id,
                    Address = u.Address,
                    FullName = u.FullName,
                    UserName = u.UserName
                });
                
            }

            return View(usersVMs);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM obj)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(obj);
                }
                var res = await signInManager.PasswordSignInAsync(obj.UserName, obj.Password,obj.RememeberMe,false);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Student");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is not correct ");
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                return View(obj);

            }
        }  
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(obj); 
                }
                var user = new SysUser
                {
                    FullName = obj.UserName,
                    UserName = obj.UserName,
                    Address = obj.Address
                };
                var res = await userManager.CreateAsync(user , obj.Password);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach(var error in res.Errors)
                    { 
                        ModelState.AddModelError("",error.Description);

                    }
                   

                    return View(obj);
                }

            }catch (Exception ex)
            { 
                return View(obj);
            }
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Student");
        }
    }
}
