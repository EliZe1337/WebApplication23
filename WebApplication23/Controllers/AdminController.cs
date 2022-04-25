using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication23.Database;

namespace WebApplication23.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserrep _basecon;
        public static bool ISAdmin = false;
        public AdminController(IUserrep us)
        {
            _basecon = us;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }

        public async Task<IActionResult> ShwAllThem()
        {
            var them = await _basecon.ShwAllThem();
            return View(them);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            //проверка на логирование
            var name = model.UserName;
            int b = await _basecon.Loggging(name);
            if(b == 1)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.UserName),
                    new Claim(ClaimTypes.Role,"Administrator")
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookie", claimPrincipal);

                return Redirect("/Them/ShwAllUser");
            }
            else if (b == 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.UserName),
                    new Claim(ClaimTypes.Role,"Manager")
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookie", claimPrincipal);

                return Redirect("/Them/ShwAllUser");
            }
            else
            {
                return Redirect("/Home/Index");
            }
            //await _basecon.Create(model);
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name,model.UserName),
            //    new Claim(ClaimTypes.Role,"Administrator")
            //};
            //var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            //var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            //await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return null;
            //return Redirect(model.ReturnUrl);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            await _basecon.Create(model);
            return await Login(model);
           //return Redirect("/Them/ShwAllUser");
        }
       
        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Them/ShwAllUser");
        }
    }
}
