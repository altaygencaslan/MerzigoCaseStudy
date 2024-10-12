using Helper.Classes;
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
        Task<ResultDto<UserDto>> CreateAsync(CreateUserDto item, CancellationToken token);
        Task<ResultDto<UserDto>> ReadAsync(Guid id, CancellationToken token);
        Task<ResultDto<IEnumerable<UserDto>>> ReadAsync(CancellationToken token);
        Task<ResultDto<UserDto>> UpdateAsync(UpdateUserDto item, CancellationToken token);
        Task<ResultDto<bool>> DeleteAsync(Guid id, CancellationToken token);
    }
}
