using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FlowFilter.Data;
using FlowFilter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowFilter.Controllers
{
    public class LoginController : Controller
    {
        private readonly FlowFilterContext db;
        public LoginController(FlowFilterContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            var password =
                Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(viewModel.Password)));
            var userInfo = await db.UserInfos.FirstOrDefaultAsync(s => s.Name == viewModel.Username && s.Password == password);
            if (userInfo == null)
            {
                return NotFound();
            }
            var claimIdentity = new ClaimsIdentity("Cookie");
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, userInfo.Name));
            Enum.GetValues(typeof(Access)).Cast<Access>().ToList().ForEach(s =>
            {
                if ((userInfo.UserAccess & s) == s)
                {
                    claimIdentity.AddClaim(new Claim(ClaimTypes.Role, s.ToString()));
                }
            });
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Role, userInfo.UserAccess.ToString()));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "Home"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "Log"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "AppRule"));

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            // 在上面注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme。

            await HttpContext.SignInAsync(claimsPrincipal);

            userInfo.LastLoginTime = DateTime.Now;
            await db.SaveChangesAsync();

            var returnUrl = Request.Form["ReturnUrl"].ToString();
            return Content(string.IsNullOrEmpty(returnUrl)
                ? $"/?r={Guid.NewGuid()}"
                : returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect($"~/?r={Guid.NewGuid()}");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}