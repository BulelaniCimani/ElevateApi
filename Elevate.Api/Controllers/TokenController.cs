using System.Threading.Tasks;
using Elevate.Api.Application.Queries.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetToken([FromQuery] string humanId)
        {
            var response = await _mediator.Send(new GetTokenQueryRequest(humanId));

            return Ok(response);
        }


    }
}
