using ContentAPI.Business.DTOs;
using ContentAPI.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ContentDto> CreateAsync(CreateContentDto item, CancellationToken token)
        {
            var entity = item.Adapt<Content>();
            entity.CreatedDate = DateTime.Now;

            _dbContext.Add(entity);
            int record = await _dbContext.SaveChangesAsync();

            return entity.Adapt<ContentDto>();
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == id, token);

            if (entity == null)
                return false;

            //Logic silme
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.Now;

            //Gerçek silme
            //_dbContext.Remove(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return record != 0;
        }

        public async Task<ContentDto> ReadAsync(Guid iditem, CancellationToken token)
        {
            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == iditem, token);
            return entity.Adapt<ContentDto>();
        }

        public async Task<IEnumerable<ContentDto>> ReadAsync(CancellationToken token)
        {
            //Yukarda Logic silme yapıldığı için burada IsDelted'ların Filtrelenmesi için bir parametere iyi olacaktır
            //Ancak case içeriğine sadık kalınması açısından eklenmedi,

            var listOfEntity = await _dbContext.Contents.ToListAsync(token);
            return listOfEntity.Adapt<IEnumerable<ContentDto>>();
        }

        public async Task<ContentDto> UpdateAsync(UpdateContentDto item, CancellationToken token)
        {
            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == item.Id, token);
            if (entity == null)
                return null;

            entity.Header = item.Header;
            entity.Body = item.Body;
            entity.Tags = item.Tags;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedUserId = item.UpdateUserId;

            _dbContext.Update(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return entity.Adapt<ContentDto>();

        }
    }
}
