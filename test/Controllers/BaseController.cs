using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected int LoggedInUserId
        {
            get
            {
                return GetLoggedInUserId();
            }
        }
        protected string LoggedInUserRole
        {
            get
            {
                return GetLoggedInUserRole();
            }
        }
        protected int GetLoggedInUserId()
        {
            var UserIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            if (UserIdClaim == null || !int.TryParse(UserIdClaim, out int parsedUserId))
            {
                throw new Exception("Logged ID claim is missing or invalid");
            }

            return parsedUserId;
        }
        protected string GetLoggedInUserRole()
        {
            var roleClaim = User.FindFirst(ClaimTypes.Role);

            return roleClaim?.Value ?? "";
        }
    }
}
