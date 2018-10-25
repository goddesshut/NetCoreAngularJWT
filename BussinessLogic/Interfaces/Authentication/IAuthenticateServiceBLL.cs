using Models.ViewModels;

namespace BussinessLogic.Interfaces
{
    public interface IAuthenticateServiceBLL: IBaseBussinessLogic
    {
        string Authenticate(AuthenticationViewModel model);

        void Logout(string username);
    }
}
