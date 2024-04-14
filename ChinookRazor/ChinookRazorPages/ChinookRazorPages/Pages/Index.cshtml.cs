/*
Kaden Parfait
C00493778
CMPS 358 .NET/C# Programming
ChinookRazorPages Project
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookRazorPages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
    [BindProperty]
    public string Genre { get; set; }
    
    [BindProperty]
    public string Artist { get; set; }
    
    [BindProperty]
    public string Composer { get; set; }
    
    [BindProperty]
    public string ChosenGenre { get; set; }
    
    [BindProperty]
    public string ChosenArtist { get; set; }
}