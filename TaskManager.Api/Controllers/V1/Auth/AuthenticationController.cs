using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.IAppService.Auth;
using TaskManager.Model.Auth.Authentication;

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
        public async Task<UserLoginModel> GetToken(string userAccount, string pwd)
        {
            return await this.Service.GetTokenAsync(userAccount, pwd);
        }
    }
}
