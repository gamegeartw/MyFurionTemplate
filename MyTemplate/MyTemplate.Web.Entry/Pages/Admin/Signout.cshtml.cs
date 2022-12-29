using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages.Admin;

public class Signout : PageModel
{
    public void OnGet()
    {
        SignOut();
        Response.Redirect(new PathString("/"));
    }
}