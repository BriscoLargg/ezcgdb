using System.Threading.Tasks;

namespace ezcgdb.Shared
{
    public interface IAuthService
    {
        Task<string> Login(LoginRequest loginRequest, string returnUrl);
        Task<string> Logout();
        Task<CurrentUser> CurrentUserInfo();
    }
}
