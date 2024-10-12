using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Business.DTOs;

namespace UserAPI.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserDto> Create(CreateUserDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Update(UpdateUserDto item)
        {
            throw new NotImplementedException();
        }
    }
}
