using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MyTemplate.Web.Entry.Pages.Admin;
[Authorize(Roles = "Admin")]
public class Index : PageModel
{
    public IndexViewModel IndexViewModel { get; set; }
    public Index()
    {
        IndexViewModel = new IndexViewModel();
        IndexViewModel.Breadcrumb = Request.Path.Value.Split('/');
    }
    public void OnGet()
    {
        IndexViewModel.Breadcrumb = Request.Path.Value.Split('/');
    }
}

public class IndexViewModel
{
    public string[] Breadcrumb { get; set; }
}