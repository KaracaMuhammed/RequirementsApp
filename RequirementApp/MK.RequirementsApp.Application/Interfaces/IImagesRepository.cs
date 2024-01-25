using MK.RequirementsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.Interfaces
{
    public interface IImagesRepository
    {
        Task<Image> Create(Image newImage);
        Task<IEnumerable<Image>> GetAll();
        Task Delete(int imageId);
        Task<Image> GetByProductId(int productId);
    }
}
