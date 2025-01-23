using test.ViewModel;
using test.Helpers;

namespace test.IRepositories
{
    public interface IAuthRepository
    {
        Task<BaseResponseObject<LoginResponse>> Login(LoginRequest entity);
    }
}
