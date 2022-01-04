using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TaskManager.IAppService.UserManager;
using TaskManager.Model;
using TaskManager.Model.UserManager.User;

namespace TaskManager.Api.Controllers.V1.UserManager
{
    //[OpenApiTag("User", Description = "用户管理")]
    public class UserController : ApiV1Controller<IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [HttpGet("{id}")]
        [Description("根据id获取用户信息")]
        public async Task<GetUserModel> GetByIdAsync([FromRoute]int id)
        {
            return await this.Service.GetByIdAsync(id);
        }

        [HttpGet]
        [Description("分页获取数据")]
        public async Task<Pagination<GetUserModel>> GetPageAsync([FromQuery]QueryUserModel input)
        {
            return await this.Service.GetPageAsync(input);
        }

        [HttpPut("{id}")]
        [Description("修改数据")]
        public async Task<int> UpdateAsync([FromRoute]int id, [FromBody] EditUserModel model)
        {
            return await this.Service.EditAsync(id, model);
        }

        [HttpPost]
        [Description("批量修改数据")]
        public async Task UpdateAllAsync([FromBody] IEnumerable<EditUserModel> models)
        {
            await this.Service.EditAsync(models);
        }

    }
}
