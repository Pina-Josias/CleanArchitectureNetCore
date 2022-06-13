using CleanArchitecture.Application.Features.Actors.Queries.PaginationActor;
using CleanArchitecture.Application.Features.Actors.Queries.Vms;
using CleanArchitecture.Application.Features.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("pagination", Name = "PaginationActor")]
        [ProducesResponseType(typeof(PaginationVm<ActorVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVm<ActorVm>>> GetPaginationActor(
            [FromQuery] PaginationActorQuery paginationActorparams)
        {
            var paginationActor = await _mediator.Send(paginationActorparams);

            return Ok(paginationActor);
        }
    }
}
