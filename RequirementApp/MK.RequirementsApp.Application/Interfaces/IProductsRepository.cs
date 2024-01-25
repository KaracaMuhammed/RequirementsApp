using MK.RequirementsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.Interfaces
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<IEnumerable<Product>> GetProductsByCompany(Company company);
        public Task<Product> Create(Product newProduct);
        public Task<Product> UpdateStatus(Product modifiedProduct);
        public Task<Product> GetById(int productId);
        public Task Delete(int productId);

    }
}
