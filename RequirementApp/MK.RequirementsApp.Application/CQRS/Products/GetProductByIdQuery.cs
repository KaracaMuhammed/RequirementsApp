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
    public class GetProductByIdQuery : IRequest<Product> 
    {
        public int ProductId { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IUnitofWork uow;
        public GetProductByIdQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await uow.ProductsRepository.GetById(request.ProductId);
        }
    }
}
