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
        Task<UserDto> CreateAsync(CreateUserDto item, CancellationToken token);
        Task<UserDto> ReadAsync(Guid id, CancellationToken token);
        Task<IEnumerable<UserDto>> ReadAsync(CancellationToken token);
        Task<UserDto> UpdateAsync(UpdateUserDto item, CancellationToken token);
        Task<bool> DeleteAsync(Guid id, CancellationToken token);
    }
}
