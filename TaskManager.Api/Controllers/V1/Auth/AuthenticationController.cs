using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.IAppService.Auth;

namespace TaskManager.Api.Controllers.V1.Auth
{
    [OpenApiTag("Authentication",Description = "鉴权验证")]
    public class AuthenticationController : ApiV1Controller<IAuthenticationService>
    {
        public AuthenticationController(IAuthenticationService service): base(service)
        {

        }

        [Description("获取token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> GetToken(string userName, string pwd)
        {
            return await this.Service.GetTokenAsync(userName, pwd);
        }

        [Description("测试Api")]
        [HttpGet]
        public async Task<string> GetTestAsyn()
        {
            return await this.Service.GetTestAsync();
        }
    }
}
