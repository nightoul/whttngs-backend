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