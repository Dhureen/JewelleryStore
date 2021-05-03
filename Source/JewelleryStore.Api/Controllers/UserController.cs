using System.Threading.Tasks;
using JewelleryStore.Application;
using JewelleryStore.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> CreateUser([FromBody] CreateUserCommand query)
        {
            return await _mediator.Send(query);
        }

        [Route("id")]
        [HttpGet]
        public async Task<UserMessage> Details(int id)
        {
            return await _mediator.Send(new UserDetailsQuery() { Id = id });
        }

        [HttpPut]
        public async Task<int> UpdateUser([FromBody] CreateUserCommand query)
        {
            return await _mediator.Send(query);
        }

        [Route("id")]
        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = id });
        }
    }
}
