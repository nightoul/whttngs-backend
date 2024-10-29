using Microsoft.AspNetCore.Mvc;
using whttngs_backend.Models;

namespace whttngs_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoViewController : ControllerBase
{
    private readonly WhttngsDbContext _context;

    public VideoViewController(WhttngsDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("trackPlayBackStart")]
    public IActionResult TrackPlayBackStart([FromBody] VideoView videoView)
    {
        _context.VideoViews.Add(videoView);
        _context.SaveChanges();
        
        return Ok(videoView);
    }

    [HttpPost]
    [Route("trackPlayBackEnd")]
    public IActionResult TrackPlayBackEnd([FromBody] VideoView videoView)
    {
        var existingVideoView = _context.VideoViews.FirstOrDefault(v => v.Id == videoView.Id);
        
        if (existingVideoView == null)
        {
            return NotFound("VideoView not found.");
        }

        existingVideoView.ViewEndPosition = videoView.ViewEndPosition;

        _context.SaveChanges();

        return Ok(existingVideoView);
    }
}