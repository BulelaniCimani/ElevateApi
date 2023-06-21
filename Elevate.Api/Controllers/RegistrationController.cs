using System.Threading.Tasks;
using Elevate.Api.Application.Commands.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {

        private readonly IMediator _mediator;
        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register(RegistrationCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }


    }
}
