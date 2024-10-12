using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Business.DTOs;

namespace UserAPI.Business.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> Create(CreateUserDto item);
        Task<UserDto> Read(Guid id);
        Task<IEnumerable<UserDto>> Read();
        Task<UserDto> Update(UpdateUserDto item);
        Task<bool> Delete(Guid id);
    }
}
