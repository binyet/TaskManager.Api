using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;
using TaskManager.Model.UserManager.User;

namespace TaskManager.IAppService.UserManager
{
    public interface IUserService 
    {
        Task<int> CreateAsync(AddUserModel model);
        Task CreateAsync(IEnumerable<AddUserModel> models);
        Task<int> EditAsync(int id, EditUserModel model);
        Task EditAsync(IEnumerable<EditUserModel> models);
        Task DeleteAsync(int id);
        Task DeleteAsync(IEnumerable<int> ids);
        Task<Pagination<GetUserModel>> GetPageAsync(QueryUserModel input);
        Task<GetUserModel> GetByIdAsync(int id);
    }
}
