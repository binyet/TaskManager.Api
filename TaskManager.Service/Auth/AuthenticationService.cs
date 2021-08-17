using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.IAppService.Auth;

namespace TaskManager.Service.Auth
{
    public class AuthenticationService : ApplicationService<AuthenticationService>, IAuthenticationService
    {
        public AuthenticationService(ILogger<AuthenticationService> logger): base(logger)
        {

        }
        public async Task<string> GetTestAsync()
        {
            return "ServiceTest";
        }
    }
}
