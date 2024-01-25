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
    public class DeleteProductCommand : IRequest<Product>
    {
        public int ProductId { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IUnitofWork uow;
        public DeleteProductCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await uow.ProductsRepository.GetById(request.ProductId);

            if (product != null)
                await uow.ProductsRepository.Delete(request.ProductId);

            await uow.Commit();
            return product;
        }
    }
}
