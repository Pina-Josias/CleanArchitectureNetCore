using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userName}", Name = "GetVideo")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<VideosVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>> GetVideosByUserName(string userName)
        {
            var query = new GetVideosListQuery(userName);
            var videos = await _mediator.Send(query);

            return Ok(videos);
        }
    }
}
