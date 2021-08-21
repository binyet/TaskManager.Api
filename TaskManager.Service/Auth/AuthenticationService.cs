using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.IAppService.Auth;
using TaskManager.Model.Auth.Authentication;

namespace TaskManager.Service.Auth
{
    public class AuthenticationService : ApplicationService<AuthenticationService>, IAuthenticationService
    {
        private IOptions<JwtSettings> JwtSettingOption { get; set; } 
        public AuthenticationService(ILogger<AuthenticationService> logger, IOptions<JwtSettings> options): base(logger)
        {
            this.JwtSettingOption = options;
        }
        public async Task<string> GetTestAsync()
        {
            return "ServiceTest";
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
