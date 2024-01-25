using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.Application.CQRS.Products
{
    public class AddProductCommand : IRequest<Product>
    {
        public ProductDTO ProductDTO { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IUnitofWork uow;
        public AddProductCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            var companies = new List<Company>();
            var productDTO = request.ProductDTO;

            foreach (var id in request.ProductDTO.CompaniesIds)
                companies.Add(await uow.CompaniesRepository.GetById(id));

            Product product = new Product() { 
                Name = productDTO.Name,
                Importance = productDTO.Importance,
                Status = productDTO.Status,
                Companies = companies,
            };

            Product currentProduct = await uow.ProductsRepository.Create(product);
            await uow.Commit();


            Console.WriteLine(currentProduct.Id);

            Image image = new Image()
            {
                ProductId = currentProduct.Id,
                ProductImage = Convert.FromBase64String(productDTO.Image)
            };

            uow.ImagesRepository.Create(image);
            await uow.Commit();

            return product;
        }
    }

}
