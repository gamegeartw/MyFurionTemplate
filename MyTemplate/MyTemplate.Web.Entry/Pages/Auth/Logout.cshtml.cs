using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages.Auth;

[AllowAnonymous]
public class Logout : PageModel
{
    public void OnGet()
    {
        SignOut();
        Response.Redirect(new PathString("/"));
    }
}