using System.Threading.Tasks;
using JewelleryStore.Application;
using JewelleryStore.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoldPriceController : Controller
    {
        private IMediator _mediator;
        public GoldPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<GoldPriceMessage> ComputeGoldPrice([FromBody] ComputeGoldPriceQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
