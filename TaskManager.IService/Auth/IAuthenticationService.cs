using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.IAppService.Auth
{
    public interface IAuthenticationService
    {
        public Task<string> GetTestAsync();
        Task<string> GetTokenAsync(string userName, string pwd);
    }
}
