using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Business.DTOs;
using UserAPI.Domain;

namespace UserAPI.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto item, CancellationToken token)
        {
            var entity = item.Adapt<User>();
            entity.CreatedDate = DateTime.Now;

            _dbContext.Add(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return entity.Adapt<UserDto>();
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, token);

            //Admin kaydının silinmemesi için IsDeleteable kontrolü:
            if (entity == null || !entity.IsDeletable)
                return false;

            //Logic silme
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.Now;

            //Gerçek silme
            //_dbContext.Remove(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return record != 0;
        }

        public async Task<UserDto> ReadAsync(Guid id, CancellationToken token)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, token);
            return entity.Adapt<UserDto>();
        }

        public async Task<IEnumerable<UserDto>> ReadAsync(CancellationToken token)
        {
            //Yukarda Logic silme yapıldığı için burada IsDelted'ların Filtrelenmesi için bir parametere iyi olacaktır
            //Ancak case içeriğine sadık kalınması açısından eklenmedi,

            var listOfEntity = await _dbContext.Users.ToListAsync(token);
            return listOfEntity.Adapt<IEnumerable<UserDto>>();
        }

        public async Task<UserDto> UpdateAsync(UpdateUserDto item, CancellationToken token)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == item.Id, token);
            if (entity == null)
                return null;

            if (!string.IsNullOrEmpty(item.FirstName))
                entity.FirstName = item.FirstName;

            if (!string.IsNullOrEmpty(item.LastName))
                entity.LastName = item.LastName;

            if (item.UpdatedUserId != Guid.Empty)
            {
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = item.UpdatedUserId;
            }

            if (item.TotalContents is > 0)
                entity.TotalContents = item.TotalContents.Value;

            _dbContext.Update(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return entity.Adapt<UserDto>();
        }
    }
}
