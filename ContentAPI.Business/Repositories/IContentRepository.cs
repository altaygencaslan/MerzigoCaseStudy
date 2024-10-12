using ContentAPI.Business.DTOs;
using Helper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.Repositories
{
    public interface IContentRepository
    {
        Task<ResultDto<ContentDto>> CreateAsync(CreateContentDto item, CancellationToken token);
        Task<ResultDto<ContentDto>> ReadAsync(Guid iditem, CancellationToken token);
        Task<ResultDto<IEnumerable<ContentDto>>> ReadAsync(CancellationToken token);
        Task<ResultDto<ContentDto>> UpdateAsync(UpdateContentDto item, CancellationToken token);
        Task<ResultDto<bool>> DeleteAsync(Guid id, CancellationToken token);
    }
}
