using Microsoft.AspNetCore.Mvc;
using whttngs_backend.Models;

namespace whttngs_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private readonly WhttngsDbContext _context;

    public VisitsController(WhttngsDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("trackVisitStart")]
    public IActionResult TrackVisitStart([FromBody] Visit visit)
    {
        _context.Visits.Add(visit);
        _context.SaveChanges();
        
        return Ok(visit);
    }

    [HttpPost]
    [Route("trackVisitEnd")]
    public IActionResult TrackVisitEnd([FromBody] Visit visit)
    {
        // Find the existing visit by VisitId
        var existingVisit = _context.Visits.FirstOrDefault(v => v.VisitId == visit.VisitId);
        
        if (existingVisit == null)
        {
            // Return 404 if the visit does not exist
            return NotFound("Visit not found.");
        }

        // Update the VisitEndedAt property
        existingVisit.VisitEndedAt = DateTime.UtcNow;

        // Save changes to the database
        _context.SaveChanges();

        // Return the updated visit object
        return Ok(existingVisit);
    }
}