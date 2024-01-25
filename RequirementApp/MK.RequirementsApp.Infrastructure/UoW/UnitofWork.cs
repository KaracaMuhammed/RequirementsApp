using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Infrastructure.Contexts;

namespace MK.RequirementsApp.Infrastructure.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RequirementsContext ctxt;
        private readonly IProductsRepository productsRepo;
        private readonly ICompaniesRepository companiesRepo;
        private readonly IImagesRepository imagesRepo;
        public UnitofWork(RequirementsContext ctxt, IProductsRepository productsRepo, ICompaniesRepository companiesRepo, IImagesRepository imagesRepo)
        {
            this.ctxt = ctxt;
            this.productsRepo = productsRepo;
            this.companiesRepo = companiesRepo;
            this.imagesRepo = imagesRepo;
        }

        public IProductsRepository ProductsRepository => productsRepo;
        public ICompaniesRepository CompaniesRepository => companiesRepo;
        public IImagesRepository ImagesRepository => imagesRepo;


        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
