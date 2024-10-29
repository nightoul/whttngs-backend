using Microsoft.AspNetCore.Mvc;
using whttngs_backend.Models;

namespace whttngs_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    private readonly WhttngsDbContext _context;

    public VisitsController(WhttngsDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("trackVisitStart")]
    public async Task<IActionResult> TrackVisitStart()
    {
        // Capture the visitor's IP from the request
        var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();

        // Check if the IP address is in IPv6 format and extract the IPv4 address
        if (clientIp != null && clientIp.StartsWith("::ffff:"))
        {
            clientIp = clientIp.Substring(7); // Strip out the "::ffff:" prefix
        }

        var post = new Post
        {
            Title = clientIp,
            Content = clientIp,
            VimeoUrl = "vimeo1",
            CreatedAt = DateTime.UtcNow
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        if (string.IsNullOrEmpty(clientIp))
        {
            return BadRequest("Could not determine the client's IP address.");
        }

        // Fetch location data from an IP geolocation service
        string visitorLocation = "Unknown location1";
        try
        {
            using (var httpClient = new HttpClient())
            {
                // Replace with a reliable IP geolocation API
                var locationApiUrl = $"https://ipapi.co/{clientIp}/json/";
                var response = await httpClient.GetAsync(locationApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var locationData = await response.Content.ReadFromJsonAsync<dynamic>();
                    visitorLocation = locationData?.city ?? "Unknown location2";
                }
            }

            var post2 = new Post
            {
                Title = visitorLocation,
                Content = visitorLocation,
                VimeoUrl = "vimeo2",
                CreatedAt = DateTime.UtcNow
            };

        _context.Posts.Add(post2);
        _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching location: {ex.Message}");
        }

        // Create and save the Visit record
        var visit = new Visit
        {
            VisitorIP = clientIp,
            VisitorLocation = visitorLocation,
            VisitStartedAt = DateTime.UtcNow
        };

        _context.Visits.Add(visit);
        _context.SaveChanges();

        return Ok(visit);
    }



    [HttpPost]
    [Route("trackVisitEnd")]
    public IActionResult TrackVisitEnd([FromBody] Visit visit)
    {
        var existingVisit = _context.Visits.FirstOrDefault(v => v.Id == visit.Id);
        
        if (existingVisit == null)
        {
            return NotFound("Visit not found.");
        }

        existingVisit.VisitEndedAt = DateTime.UtcNow;

        _context.SaveChanges();

        return Ok(existingVisit);
    }
}