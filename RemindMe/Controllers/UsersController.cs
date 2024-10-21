using Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] AddUserPayload payload)
        {
            await _mediator.Send(new AddUser(payload));
            return Ok();
        }

        [HttpPost("UpdateEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailPayload payload)
        {
            await _mediator.Send(new UpdateEmail(payload));
            return Ok();
        }
    }
}
