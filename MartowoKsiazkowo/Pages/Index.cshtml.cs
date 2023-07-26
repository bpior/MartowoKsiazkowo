using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MartowoKsiazkowo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
private readonly IWebHostEnvironment _environment;
    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}