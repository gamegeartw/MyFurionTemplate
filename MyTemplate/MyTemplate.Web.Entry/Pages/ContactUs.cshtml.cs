using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages
{
    [AllowAnonymous]
    public class ContactUsModel : PageModel
    {
        [BindProperty]
        public PostData Data { get; set; }
        public void OnGet()
        {
        }

        
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                return Content("OK");
            }
            else
            {
                return Content("error");
            }

            
        }
    }

    public class PostData
    {
        [Required] public string Name { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string Content { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Subject { get; set; }
    }
}