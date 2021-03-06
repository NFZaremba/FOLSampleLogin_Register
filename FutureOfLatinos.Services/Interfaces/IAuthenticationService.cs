using System.Security.Claims;
using FutureOfLatinos.Models;

namespace FutureOfLatinos.Services
{
    public interface IAuthenticationService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="extraClaims"></param>
        /// <returns></returns>
        void LogIn(IUserAuthData user, params Claim[] extraClaims);

        /// <summary>
        /// Logs out the currently signed in user
        /// </summary>
        void LogOut();


        IUserAuthData GetCurrentUser();
    }
}
