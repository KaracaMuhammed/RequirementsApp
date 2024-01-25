using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.BlazorUI.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompanies();
    }
}
