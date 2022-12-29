using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages.Admin;

[Authorize(Roles = "Admin")]
public class Index2 : PageModel
{
    public void OnGet()
    {
        
    }
}