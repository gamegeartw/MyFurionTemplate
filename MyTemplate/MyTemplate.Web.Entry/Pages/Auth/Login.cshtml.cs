using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }

        [BindProperty] 
        [Required]
        public string Username { get; set; }

        [BindProperty] 
        [Required]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                
            }
            
            return Page();
        }
    }
}