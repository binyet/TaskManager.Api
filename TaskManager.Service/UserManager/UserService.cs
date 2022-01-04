using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.IAppService.UserManager;
using TaskManager.Model;
using TaskManager.Model.UserManager.User;
using TaskManager.Repository;

namespace TaskManager.Service.UserManager
{
    public class UserService : ApplicationService<UserService, IKeyRepository<TMUser>>, IUserService
    {
        public UserService(ILogger<UserService> logger, IKeyRepository<TMUser> repository, IMapper mapper) : base(logger, repository, mapper)
        {
        }

        public async Task<int> CreateAsync(AddUserModel model)
        {
            if (model == null)
                throw new ArgumentException("model为空");
            var entity = this.Mapper.Map<TMUser>(model);
            await this.Repository.InsertAsync(entity);
            return entity.ID;
        }

        public async Task CreateAsync(IEnumerable<AddUserModel> models)
        {
            if (!models.Any())
                throw new ArgumentException("models 为空");
            var entities = models.Select(p => this.Mapper.Map<TMUser>(p));
            await this.Repository.InsertAsync(entities);

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.Repository.FirstOrDefaultAsync(p => p.ID == id);
            if (entity == null)
            {
                throw new ArgumentException($"未找到id为{id}的数据");
            }
            await this.Repository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            var entities = await this.Repository.Where(p => ids.Contains(p.ID)).ToListAsync();
            if (!entities.Any())
            {
                throw new ArgumentException("未找到符合条件的项");
            }
            await this.Repository.DeleteAsync(entities);
        }

        public async Task EditAsync(IEnumerable<EditUserModel> models)
        {
            var entities = await this.Repository.Where(p => models.Select(p => p.ID).Contains(p.ID)).ToListAsync();
            foreach (var entity in entities)
            {
                var model = models.FirstOrDefault(p => p.ID == entity.ID);
                if (model == null) continue;
                this.Mapper.Map(model, entity);
            }
            await this.Repository.UpdateAsync(entities);
        }

        public async Task<int> EditAsync(int id, EditUserModel model)
        {
            var entity = await this.Repository.FirstOrDefaultAsync(p=>p.ID == id);
            if (entity == null)
                throw new ArgumentException($"未找到ID为{id}的数据");
            this.Mapper.Map(model, entity);
            await this.Repository.UpdateAsync(entity);
            return entity.ID;

        }

        public async Task<GetUserModel> GetByIdAsync(int id)
        {
            var entity = await this.Repository.FirstOrDefaultAsync(p => p.ID == id);
            var model = this.Mapper.Map<GetUserModel>(entity);
            return model;
        }

        public async Task<Pagination<GetUserModel>> GetPageAsync(QueryUserModel input)
        {
            var entities = await this.Repository.Page(p => p.ID, input.Page, input.Limit).ToListAsync();
            var models = entities.Select(p=>this.Mapper.Map<GetUserModel>(p)).ToList();
            return new Pagination<GetUserModel>
            {
                Count = await this.Repository.CountAsync(),
                Items = models
            };
        }
    }
}
