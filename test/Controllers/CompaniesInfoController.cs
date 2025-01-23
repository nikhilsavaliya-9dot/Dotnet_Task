using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Helpers;
using test.IRepository;
using test.Models;
using test.ViewModel;
using test.ViewModel.Pagination;


namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesInfoController : BaseController
    {
        private readonly ICompaniesInfoRepository _companiesInfoRepository;
        public CompaniesInfoController(ICompaniesInfoRepository companiesInfoRepository)
        {
            _companiesInfoRepository = companiesInfoRepository;
        }


        [HttpGet]
        [Route("companies/get-all-companyInfo")]
        public async Task<IActionResult> GetAllcompany([FromQuery] Pagination pagination)
        {
            var result = await _companiesInfoRepository.GetAllCompany(pagination);
            return Ok(result);
        }

        // GET api/<CompaniesInfoController>/5
        [HttpGet("companies/get-companyInfoById/{companyId}")]
        public async Task<ActionResult<BaseResponse>> GetCompanyBiId(int companyId)
        {
            var result = await _companiesInfoRepository.GetCompanyById(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }


        [HttpPost("companies/add-CompanyInfo")]

        public async Task<IActionResult> Createnewcompany([FromBody] CompanyInfoVM entity)
        {
            var result = await _companiesInfoRepository.CreateCompanyInfo(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        
        // PUT api/<CompaniesInfoController>/5
        [HttpPut("companies/update-CompanyInfo/{companyId}")]
        public async Task<ActionResult<BaseResponse>> UpdateCompanyInfo(int companyId , [FromBody] CompanyInfoVM entity)
        {
            var result = await _companiesInfoRepository.UpdateCompanyInfo(companyId,entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        // DELETE api/<CompaniesInfoController>/5
        [HttpDelete("companies/delete-CompanyInfo/{companyId}")]
        public async Task<ActionResult<BaseResponse>> DeleteCompanyInfo(int companyId)
        {
            var result = await _companiesInfoRepository.DeleteCompanyInfo(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}
