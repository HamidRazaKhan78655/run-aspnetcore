using AspnetRun.Web.ViewModels;
using static AspnetRun.Web.Controllers.api.Auth.AuthController;

namespace AspnetRun.Web.Interfaces
{
    public interface IJWTManagerPageService
    {
        public Tokens Authenticate(UsersViewModel users);
    }
}
