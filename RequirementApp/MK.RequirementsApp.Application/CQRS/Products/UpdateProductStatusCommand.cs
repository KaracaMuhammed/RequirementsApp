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
    public class UpdateProductStatusCommand : IRequest<Product>
    {
        public int ProductId { get; set; }
    }

    public class UpdateProductStatusCommandHandler : IRequestHandler<UpdateProductStatusCommand, Product>
    {
        private readonly IUnitofWork uow;
        public UpdateProductStatusCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Product> Handle(UpdateProductStatusCommand request, CancellationToken cancellationToken)
        {
            Product product = await uow.ProductsRepository.GetById(request.ProductId);

            if (product.Status == Status.NotPurchased)
                product.Status = Status.InProgress;
            else if (product.Status == Status.InProgress)
                product.Status = Status.Purchased;
            else product.Status = Status.NotPurchased;

            await uow.Commit();
            return product;
        }
    }

}
