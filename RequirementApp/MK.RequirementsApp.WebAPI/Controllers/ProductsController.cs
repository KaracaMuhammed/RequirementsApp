using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MK.RequirementsApp.Application.CQRS.Products;
using MK.RequirementsApp.Domain;
using System.Threading.Tasks;

namespace MK.RequirementsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product) 
        {
            return Ok(await mediator.Send(new AddProductCommand() { ProductDTO = product }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await mediator.Send(new GetAllProductsQuery() { }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery() { ProductId = id }));
        }

        [HttpPut]
        [Route("update/{productId}")]
        public async Task<IActionResult> UpdateProductStatus(int productId)
        {
            return Ok(await mediator.Send(new UpdateProductStatusCommand() { ProductId = productId }));
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            return Ok(await mediator.Send(new DeleteProductCommand() { ProductId = productId }));
        }

    }
}
