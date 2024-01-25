using MK.RequirementsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Application.Interfaces
{
    public interface ICompaniesRepository
    {
        public Task<Company> Create(Company newCompany);
        public Task<Company> GetById(int id);
        public Task<IEnumerable<Company>> GetAll();

    }
}
