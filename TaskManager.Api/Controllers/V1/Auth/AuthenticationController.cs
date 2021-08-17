using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.IAppService.Auth;

namespace TaskManager.Api.Controllers.V1.Auth
{
    public class AuthenticationController : ApiV1Controller<IAuthenticationService>
    {
        public AuthenticationController(IAuthenticationService service): base(service)
        {

        }

        [Description("测试Api")]
        [HttpGet]
        public async Task<string> GetTestAsyn()
        {
            return await this.Service.GetTestAsync();
        }
    }
}
