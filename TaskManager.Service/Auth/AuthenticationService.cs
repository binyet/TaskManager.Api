using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DBContext;
using TaskManager.Entities;
using TaskManager.IAppService.Auth;
using TaskManager.Model.Auth.Authentication;

namespace TaskManager.Service.Auth
{
    public class AuthenticationService : ApplicationService<AuthenticationService>, IAuthenticationService
    {
        private IOptions<JwtSettings> JwtSettingOption { get; set; } 
        public AuthenticationService(ILogger<AuthenticationService> logger, IOptions<JwtSettings> options, TaskManagerContext context): base(logger, context)
        {
            this.JwtSettingOption = options;
        }
        public async Task<string> GetTestAsync()
        {
            var user = new TMUser()
            {
                UserName = "张三"
            };
            this.Context.TMUser.Add(user);
            await this.Context.SaveChangesAsync();

            return this.Context.TMUser.FirstOrDefault().ID.ToString();
        }

        public async Task<string> GetTokenAsync(string userName, string pwd)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim("Password", pwd)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettingOption.Value.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JwtSettingOption.Value.Issuer,
                audience: JwtSettingOption.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(JwtSettingOption.Value.Expires),
                signingCredentials: creds
                );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
    }
}
