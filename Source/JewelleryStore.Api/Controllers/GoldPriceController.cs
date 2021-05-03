using System.Threading.Tasks;
using JewelleryStore.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoldPriceController : Controller
    {
        private IMediator _mediator;
        public GoldPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<float> GetTotalPrice([FromBody] GoldPriceQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
