using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.CQRS.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitofWork uow;
        public GetAllProductsQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await uow.ProductsRepository.GetAll();
            return products;
        }
    }
}
