using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model.Auth.Authentication;

namespace TaskManager.IAppService.Auth
{
    public interface IAuthenticationService
    {
        Task<UserLoginModel> GetTokenAsync(string userAccount, string pwd);
    }
}
