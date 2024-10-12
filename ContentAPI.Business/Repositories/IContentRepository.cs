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
        Task<ContentDto> Create(CreateContentDto item);
        Task<ContentDto> Read(Guid id);
        Task<IEnumerable<ContentDto>> Read();
        Task<ContentDto> Update(UpdateContentDto item);
        Task<bool> Delete(Guid id);
    }
}
