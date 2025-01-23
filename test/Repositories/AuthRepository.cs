using test.Data;
using test.Helpers;
using test.IRepositories;
using test.Models;
using test.Services;
using test.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace test.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthRepository(AppDbContext dbContext, TokenService tokenService, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._tokenService = tokenService;
            this._configuration = configuration;
        }

        public async Task<BaseResponseObject<LoginResponse>> Login(LoginRequest entity)
        {
            try
            {
                LoginResponse tokenVM = new();

                var userDetailsMaster = await _dbContext.User.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == entity.Email);

                if (userDetailsMaster == null)
                    return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.UserNotFound };

                bool IsUserCredentialsValid = EncryptionHelper.DecryptString(userDetailsMaster.Password) == entity.Password;

                if (!IsUserCredentialsValid)
                    return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.PasswordNotMatch };

                if (!userDetailsMaster.IsActive)
                    return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.UserInActive };
                var token = await CreateUserToken(userDetailsMaster);

                if (token.Token != null)
                {
                    tokenVM.AuthToken = token.Token;
                    tokenVM.RoleId = token.RoleId;
                    tokenVM.ExpiredIn = Convert.ToInt32(_configuration["JwtConfig:accessTokenExpiration"]);
                    tokenVM.Role = token.RoleName;
                    tokenVM.Id = userDetailsMaster.UserId;
                    tokenVM.Email = userDetailsMaster.Email;
                    tokenVM.MobileNo = userDetailsMaster.PhoneNo;
                    tokenVM.IsActive = userDetailsMaster.IsActive;
                }

                return new BaseResponseObject<LoginResponse> { Data = tokenVM, Success = true, Message = ResponseMessage.LoginSuccessfully };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // private method

        private async Task<(string? RoleName, int RoleId, string? Token)> CreateUserToken(User userDetailsMaster)
        {
            string? RoleName = await (from role in _dbContext.RoleMaster
                                      where role.RoleId == (int)userDetailsMaster.RoleId
                                      select role.RoleName).AsNoTracking().FirstOrDefaultAsync();

            var token = _tokenService.GenerateToken(userDetailsMaster.UserId, RoleName, userDetailsMaster.Email);

            return (RoleName, (int)userDetailsMaster.RoleId, token);
        }
    }
}
