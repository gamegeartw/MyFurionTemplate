using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTemplate.Application;

namespace MyTemplate.Web.Entry.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ISystemService _service;
        public string ReturnUrl { get; set; }
         public UserViewModel UserModel { get; set; }

        public LoginModel(ISystemService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(UserViewModel UserModel)
        {
            if (ModelState.IsValid)
            {
                var userModel = await _service.Login(UserModel.Account, UserModel.Password);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.Name),
                };
                foreach (var role in userModel.Roles)   
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Admin/Index");
            }

            return Page();
        }
    }

    public class UserViewModel
    {
        [BindProperty]public string Account { get; set; }
        
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}