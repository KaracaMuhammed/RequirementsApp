using Microsoft.EntityFrameworkCore;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;
using MK.RequirementsApp.Infrastructure.Contexts;

namespace MK.RequirementsApp.Infrastructure.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {

        private readonly RequirementsContext context;

        public CompaniesRepository(RequirementsContext context)
        {
            this.context = context;
        }

        public async Task<Company> Create(Company newCompany)
        {
            await context.Companies.AddAsync(newCompany);
            return newCompany;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await context.Companies.FirstOrDefaultAsync(p => p.Id == id);
        }

        
    }
}
