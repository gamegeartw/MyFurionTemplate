using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages
{
    [AllowAnonymous]
    public class AboutUsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
