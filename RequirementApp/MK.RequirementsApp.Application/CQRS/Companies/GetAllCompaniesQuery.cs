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
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>> { }

    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
    {
        private readonly IUnitofWork uow;
        public GetAllCompaniesQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await uow.CompaniesRepository.GetAll();
        }
    }
}
