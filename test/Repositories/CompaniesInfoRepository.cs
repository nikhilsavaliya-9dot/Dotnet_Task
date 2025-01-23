using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using test.Data;
using test.Helpers;
using test.IRepository;
using test.Models;
using test.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace test.Repositories
{
    public class CompaniesInfoRepository : ICompaniesInfoRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public CompaniesInfoRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        // Helper method to map CompanyInfo to CompanyInfoVM
        private static CompanyInfoVM MapToViewModel(CompanyInfo company) => new CompanyInfoVM
        {
            AccountsCreatorURL = company.AccountsCreatorURL,
            AcquisitionDate = company.AcquisitionDate,
            Address = company.Address,
            AndroidBuild = company.AndroidBuild,
            ApiBaseUrl = company.ApiBaseUrl,
            Canceled = company.Canceled,
            CompanyName = company.CompanyName,
            ContactNumber = company.ContactNumber,
            CreatedAt = company.CreatedAt,
            DemoAccountNodeId = company.DemoAccountNodeId,
            Email = company.Email,
            FacebookUrl = company.FacebookUrl,
            ForceUpgrade = company.ForceUpgrade,
            HelpPageUrl = company.HelpPageUrl,
            Id = company.Id,
            iOSBuild = company.iOSBuild,
            IpAddressV4 = company.IpAddressV4,
            LinkedInUrl = company.LinkedInUrl,
            LogoUrl = company.LogoUrl,
            MacAddress = company.MacAddress,
            PhysicalAddress = company.PhysicalAddress,
            PlatformFeatures = company.PlatformFeatures,
            PrivacyPolicyUrl = company.PrivacyPolicyUrl,
            Suspended = company.Suspended,
            TermsOfServiceUrl = company.TermsOfServiceUrl,
            WebsiteUrl = company.WebsiteUrl,
            WhatsNew = company.WhatsNew,
            XUrl = company.XUrl,
            YouTubeUrl = company.YouTubeUrl
        };

        // Helper method to map CompanyInfoVM to CompanyInfo
        private static void UpdateCompanyFromViewModel(CompanyInfo company, CompanyInfoVM entity)
        {
            company.AccountsCreatorURL = entity.AccountsCreatorURL;
            company.AcquisitionDate = entity.AcquisitionDate;
            company.Address = entity.Address;
            company.AndroidBuild = entity.AndroidBuild;
            company.ApiBaseUrl = entity.ApiBaseUrl;
            company.Canceled = entity.Canceled;
            company.CompanyName = entity.CompanyName;
            company.ContactNumber = entity.ContactNumber;
            company.DemoAccountNodeId = entity.DemoAccountNodeId;
            company.Email = entity.Email;
            company.FacebookUrl = entity.FacebookUrl;
            company.ForceUpgrade = entity.ForceUpgrade;
            company.HelpPageUrl = entity.HelpPageUrl;
            company.iOSBuild = entity.iOSBuild;
            company.IpAddressV4 = entity.IpAddressV4;
            company.LinkedInUrl = entity.LinkedInUrl;
            company.LogoUrl = entity.LogoUrl;
            company.MacAddress = entity.MacAddress;
            company.PhysicalAddress = entity.PhysicalAddress;
            company.PlatformFeatures = entity.PlatformFeatures;
            company.PrivacyPolicyUrl = entity.PrivacyPolicyUrl;
            company.Suspended = entity.Suspended;
            company.TermsOfServiceUrl = entity.TermsOfServiceUrl;
            company.WebsiteUrl = entity.WebsiteUrl;
            company.WhatsNew = entity.WhatsNew;
            company.XUrl = entity.XUrl;
            company.YouTubeUrl = entity.YouTubeUrl;
        }

        public async Task<BaseResponseModel<IEnumerable<CompanyInfoVM>>> GetAllCompany()
        {
            try
            {
                var companies = _dbContext.CompanyInfo.AsNoTracking()
                    .Select(MapToViewModel).ToList();

                return new BaseResponseModel<IEnumerable<CompanyInfoVM>>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    Data = companies,
                    TotalRecords = companies.Count()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponseObject<CompanyInfoVM>> GetCompanyById(int companyId)
        {
            try
            {
                var company = _dbContext.CompanyInfo.AsNoTracking()
                    .Where(x => x.Id == companyId)
                    .Select(MapToViewModel).FirstOrDefault();

                if (company == null)
                {
                    return new BaseResponseObject<CompanyInfoVM>
                    {
                        Success = false,
                        Message = ResponseMessage.DataNotFound
                    };
                }

                return new BaseResponseObject<CompanyInfoVM>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    Data = company
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponse> CreateCompanyInfo(CompanyInfoVM entity)
        {
            try
            {
                var company = new CompanyInfo
                {
                    CreatedAt = DateTime.UtcNow
                };

                UpdateCompanyFromViewModel(company, entity);

                await _dbContext.CompanyInfo.AddAsync(company);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Code = 200,
                    Message = "New data added successfully.",
                    Success = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponseObject<CompareInfo>> UpdateCompanyInfo(int companyId, CompanyInfoVM entity)
        {
            try
            {
                var company = await _dbContext.CompanyInfo.FirstOrDefaultAsync(x => x.Id == companyId);
                if (company == null)
                {
                    return new BaseResponseObject<CompareInfo>
                    {
                        Success = false,
                        Message = ResponseMessage.DataNotFound
                    };
                }

                UpdateCompanyFromViewModel(company, entity);
                company.UpdatedAt = DateTime.UtcNow;

                _dbContext.CompanyInfo.Update(company);
                await _dbContext.SaveChangesAsync();

                return new BaseResponseObject<CompareInfo>
                {
                    Success = true,
                    Message = ResponseMessage.UpdateCompanyInfo
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponse> DeleteCompanyInfo(int companyId)
        {
            try
            {
                var company = await _dbContext.CompanyInfo.FirstOrDefaultAsync(x => x.Id == companyId);
                if (company == null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = ResponseMessage.DataNotFound
                    };
                }

                _dbContext.CompanyInfo.Remove(company);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = "Company information deleted successfully."
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
