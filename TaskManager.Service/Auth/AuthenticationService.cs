using AutoMapper;
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
using TaskManager.Repository;
using TaskManager.Utility;

namespace TaskManager.Service.Auth
{
    public class AuthenticationService : ApplicationService<AuthenticationService, IKeyRepository<TMUser>>, IAuthenticationService
    {
        private IOptions<JwtSettings> JwtSettingOption { get; set; }
        public AuthenticationService(ILogger<AuthenticationService> logger, IOptions<JwtSettings> options, IKeyRepository<TMUser> repository, IMapper mapper) : base(logger, repository, mapper)
        {
            this.JwtSettingOption = options;
        }

        public async Task<UserLoginModel> GetTokenAsync(string userAccount, string pwd)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAccount),
                new Claim("Password", pwd)
            };
            var user = await this.Repository.FirstOrDefaultAsync(p => p.UserAccount == userAccount);
            if (user == null)
            {
                return new UserLoginModel
                {
                    Details = "用户不存在",
                    LoginResult = 0,
                    Token = ""
                };
            }
            string aesKey = "binyet1234567890binyet1234567890";
            var password = AESEncrypHelper.AesEncrypt(pwd, aesKey);
            if(password != user.Password)
            {
                return new UserLoginModel
                {
                    Details = "用户名/密码错误",
                    LoginResult = 2,
                    Token = ""
                };
            }
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
            return new UserLoginModel
            {
                Token = tokenStr,
                Details = "登录成功",
                LoginResult = 1
            };
        }
    }
}
