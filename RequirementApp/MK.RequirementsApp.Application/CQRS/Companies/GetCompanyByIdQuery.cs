using MediatR;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.Application.CQRS.Companies
{
    public class GetCompanyByIdQuery : IRequest<IEnumerable<Company>> { }

    //public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, IEnumerable<Company>>
    //{
    //    private readonly IUnitofWork uow;
    //    public GetCompanyByIdQueryHandler(IUnitofWork uow)
    //    {
    //        this.uow = uow;
    //    }

    //    public async Task<IEnumerable<Company>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        return await uow.CompaniesRepository.Get
    //    }
    //}
}
