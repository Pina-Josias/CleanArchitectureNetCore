using CleanArchitecture.Application.Features.Shared.Queries;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Features.Videos.Queries.PaginationVideos;
using CleanArchitecture.Application.Features.Videos.Queries.Vms;
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

        [HttpGet("pagination", Name = "PaginationVideo")]
        [ProducesResponseType(typeof(PaginationVm<VideosWithIncludesVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVm<VideosWithIncludesVm>>> GetPaginationVideo(
                [FromQuery] PaginationVideosQuery paginationVideosParams
            )
        {
            var paginationVideo = await _mediator.Send(paginationVideosParams);

            return Ok(paginationVideo);

        }
    }
}
