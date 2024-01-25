using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.Interfaces
{
    public interface IUnitofWork
    {
        public IProductsRepository ProductsRepository { get; }
        public ICompaniesRepository CompaniesRepository { get; }
        public IImagesRepository ImagesRepository { get; }
        public Task Commit();
    }
}
