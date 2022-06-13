using CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;
using CleanArchitecture.Application.Features.Directors.Queries.PaginationDirector;
using CleanArchitecture.Application.Features.Directors.Queries.Vms;
using CleanArchitecture.Application.Features.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IMediator _mediator;

        public DirectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("pagination", Name = "PaginationDirector")]
        [ProducesResponseType(typeof(PaginationVm<DirectorVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationVm<DirectorVm>>> GetPaginationDirector([FromQuery] PaginationDirectorsQuery paginationDirectorsQuery)
        {
            var paginationDirector = await _mediator.Send(paginationDirectorsQuery);
            return Ok(paginationDirector);
        }

        // POST api/<DirectorController>
        [HttpPost(Name = "CreateDirector")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<int>> CreateDirector([FromBody] CreateDirectorCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
