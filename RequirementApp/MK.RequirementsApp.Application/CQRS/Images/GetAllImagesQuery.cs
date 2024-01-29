using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.Application.CQRS.Companies
{
    public class GetAllImagesQuery : IRequest<IEnumerable<ImageDTO>> { }

    public class GetAllImagesQueryHandler : IRequestHandler<GetAllImagesQuery, IEnumerable<ImageDTO>>
    {
        private readonly IUnitofWork uow;
        public GetAllImagesQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ImageDTO>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            var allImages = new List<ImageDTO>();
            foreach (var image in await uow.ImagesRepository.GetAll())
            {
                allImages.Add(new ImageDTO
                {
                    Id = image.Id,
                    ProductImage = Convert.ToBase64String(image.ProductImage),
                    ProductId = image.ProductId
                });
            }
            return allImages;
        }
    }
}
