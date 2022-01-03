using Microsoft.AspNetCore.Mvc;
using TaskManager.IAppService.UserManager;

namespace TaskManager.Api.Controllers.V1.UserManager
{
    public class UserController : ApiV1Controller<IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
