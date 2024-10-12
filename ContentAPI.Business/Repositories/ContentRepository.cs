using ContentAPI.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly ContentDbContext _dbContext;
        public ContentRepository(ContentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ContentDto> Create(CreateContentDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContentDto> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContentDto>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<ContentDto> Update(UpdateContentDto item)
        {
            throw new NotImplementedException();
        }
    }
}
