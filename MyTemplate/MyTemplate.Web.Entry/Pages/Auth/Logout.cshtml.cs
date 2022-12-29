using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages.Auth;

public class Logout : PageModel
{
    public void OnGet()
    {
        SignOut();
        Response.Redirect(new PathString("/"));
    }
}