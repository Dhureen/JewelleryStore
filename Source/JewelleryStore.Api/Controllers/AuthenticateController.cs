using System.Threading.Tasks;
using JewelleryStore.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {

        private IMediator _mediator;
        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateQuery query)
        {
            var response = await _mediator.Send(query);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);

        }
    }
}
