using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly GoogleSearchService _googleSearchService;

    public SearchController(GoogleSearchService googleSearchService)
    {
        _googleSearchService = googleSearchService ?? throw new ArgumentNullException(nameof(googleSearchService));
    }

    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var result = await _googleSearchService.Search(query);

        return Ok(result);
    }
}
