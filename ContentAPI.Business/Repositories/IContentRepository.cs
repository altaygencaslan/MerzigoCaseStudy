using ContentAPI.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.Repositories
{
    public interface IContentRepository
    {
        Task<ContentDto> CreateAsync(CreateContentDto item, CancellationToken token);
        Task<ContentDto> ReadAsync(Guid iditem, CancellationToken token);
        Task<IEnumerable<ContentDto>> ReadAsync(CancellationToken token);
        Task<ContentDto> UpdateAsync(UpdateContentDto item, CancellationToken token);
        Task<bool> DeleteAsync(Guid id, CancellationToken token);
    }
}
