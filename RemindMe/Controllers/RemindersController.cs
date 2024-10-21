using Application.Commands.Reminders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RemindersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddReminder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddReminder([FromBody] AddReminderPayload payload)
        {
            await _mediator.Send(new AddReminder(payload));
            return Ok();
        }

        [HttpPost("UpdateReminder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateReminder([FromBody] UpdateReminderPayload payload)
        {
            await _mediator.Send(new UpdateReminder(payload));
            return Ok();
        }

        [HttpPost("RemoveReminder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveReminder([FromBody] RemoveReminderPayload payload)
        {
            await _mediator.Send(new RemoveReminder(payload));
            return Ok();
        }
    }
}
