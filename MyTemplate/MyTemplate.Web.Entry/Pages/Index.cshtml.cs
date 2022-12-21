using MyTemplate.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyTemplate.Web.Entry.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly ISystemService _systemService;

        public IndexModel(
            ILogger<IndexModel> logger,
            ISystemService systemService)
        {
            _logger = logger;
            _systemService = systemService;
        }

        public void OnGet()
        {
            _logger.LogInformation("Hello World!");
            ViewData["Description"] = _systemService.GetDescription();
        }
    }
}