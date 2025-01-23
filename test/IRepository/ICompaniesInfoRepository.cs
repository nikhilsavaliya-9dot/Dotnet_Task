using System.Globalization;
using test.Helpers;
using test.Models;
using test.ViewModel;
using test.ViewModel.Pagination;

namespace test.IRepository
{
    public interface ICompaniesInfoRepository
    {
        Task<BaseResponseModel<IEnumerable<CompanyInfoVM>>> GetAllCompany(Pagination pagination);
        Task<BaseResponseObject<CompanyInfoVM>> GetCompanyById(int companyId);
        Task<BaseResponse> CreateCompanyInfo(CompanyInfoVM entity); 
        Task<BaseResponse> DeleteCompanyInfo(int companyId); 
        Task<BaseResponseObject<CompareInfo>> UpdateCompanyInfo(int companyId, CompanyInfoVM entity); 
    }
}   
