using test.Helpers;
using test.IRepositories;
using test.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Controllers;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthRepository _authRepository;
        public AuthenticationController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest entity)
        {
            var result = await _authRepository.Login(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        
    }
}
