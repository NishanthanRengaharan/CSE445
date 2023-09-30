using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MapController : ControllerBase
{
    private readonly GoogleMapsService _googleMapsService;

    public MapController(GoogleMapsService googleMapsService)
    {
        _googleMapsService = googleMapsService;
    }

    [HttpGet]
    public IActionResult SearchPlaces(string query)
    {
        try
        {
            string result = _googleMapsService.SearchPlaces(query).Result;
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

