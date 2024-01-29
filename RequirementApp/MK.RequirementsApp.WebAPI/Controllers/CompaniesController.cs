using MediatR;
using Microsoft.AspNetCore.Mvc;
using MK.RequirementsApp.Application.CQRS.Companies;
using System.Threading.Tasks;

namespace MK.RequirementsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        private readonly IMediator mediator;
        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(await mediator.Send(new GetAllCompaniesQuery() { }));
        }
    }
}
