using Furion;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyTemplate.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTemplate.Application.ViewModels;

namespace MyTemplate.Web.Entry.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISystemService _systemService;

        public IndexModel(
            ILogger<IndexModel> logger,
            ISystemService systemService)
        {
            _logger = logger;
            _systemService = systemService;
        }

        public void OnGet()
        {
            ViewData["Company"] = App.GetConfig<CompanyViewModel>("Company");
            
        }
    }

}