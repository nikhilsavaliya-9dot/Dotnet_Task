using System.Globalization;
using test.Helpers;
using test.Models;
using test.ViewModel;

namespace test.IRepository
{
    public interface ICompaniesInfoRepository
    {
        Task<BaseResponseModel<IEnumerable<CompanyInfoVM>>> GetAllCompany();
        Task<BaseResponseObject<CompanyInfoVM>> GetCompanyById(int companyId);
        Task<BaseResponse> CreateCompanyInfo(CompanyInfoVM entity); 
        Task<BaseResponse> DeleteCompanyInfo(int companyId); 
        Task<BaseResponseObject<CompareInfo>> UpdateCompanyInfo(int companyId, CompanyInfoVM entity); 
    }
}   
