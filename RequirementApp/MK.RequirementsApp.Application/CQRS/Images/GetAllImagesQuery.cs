using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.CQRS.Companies
{
    public class GetAllImagesQuery : IRequest<IEnumerable<Image>> { }

    public class GetAllImagesQueryHandler : IRequestHandler<GetAllImagesQuery, IEnumerable<Image>>
    {
        private readonly IUnitofWork uow;
        public GetAllImagesQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Image>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            return await uow.ImagesRepository.GetAll();
        }
    }
}
