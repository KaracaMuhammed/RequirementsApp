using Microsoft.EntityFrameworkCore;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;
using MK.RequirementsApp.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly RequirementsContext context;

        public ProductsRepository(RequirementsContext context)
        {
            this.context = context;
        }

        public async Task<Product> Create(Product newProduct)
        {
            await context.Products.AddAsync(newProduct);
            return newProduct;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.Include(p => p.Companies).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCompany(Company company)
        {
            return await context.Products.Where(p => p.Companies.Equals(company)).Include(p => p.Companies).ToListAsync();
        }

        public async Task<Product> UpdateStatus(Product modifiedProduct)
        {
            context.Products.Update(modifiedProduct);
            return modifiedProduct;
        }

        public async Task<Product> GetById(int productId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task Delete(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            context.Products.Remove(product);
        }
    }
}
