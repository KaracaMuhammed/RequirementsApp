using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.Application.CQRS.Images
{
    public class GetActiveImagesQuery : IRequest<IEnumerable<ImageDTO>> { }

    public class GetActiveImagesQueryHandler : IRequestHandler<GetActiveImagesQuery, IEnumerable<ImageDTO>>
    {
        private readonly IUnitofWork uow;
        public GetActiveImagesQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ImageDTO>> Handle(GetActiveImagesQuery request, CancellationToken cancellationToken)
        {

            var activeProductsIds = await uow.ProductsRepository.GetActiveProductsIds();
            var allActiveImages = new List<ImageDTO>();

            foreach (var image in await uow.ImagesRepository.GetByProductIds(activeProductsIds.ToList()))
            {
                allActiveImages.Add(new ImageDTO
                {
                    Id = image.Id,
                    ProductImage = Convert.ToBase64String(image.ProductImage),
                    ProductId = image.ProductId
                });
            }
            return allActiveImages;
        }
    }
}
