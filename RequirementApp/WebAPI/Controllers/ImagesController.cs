using MediatR;
using Microsoft.AspNetCore.Mvc;
using MK.RequirementsApp.Application.CQRS.Companies;
using System.Threading.Tasks;

namespace MK.RequirementsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ImagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            return Ok(await mediator.Send(new GetAllImagesQuery() { }));
        }
    }
}
