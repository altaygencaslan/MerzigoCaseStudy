using ContentAPI.Business.DTOs;
using ContentAPI.Business.HttpClient;
using ContentAPI.Domain;
using Helper;
using Helper.Classes;
using Helper.CustomHttpClient;
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
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly CustomHttpClient _customHttpClient;
        public ContentRepository(ContentDbContext dbContext, IHttpClientHelper httpClientHelper, CustomHttpClient customHttpClient)
        {
            _dbContext = dbContext;
            _customHttpClient = customHttpClient;
        }

        public async Task<ResultDto<ContentDto>> CreateAsync(CreateContentDto item, CancellationToken token)
        {
            var entity = item.Adapt<Content>();
            entity.CreatedDate = DateTime.UtcNow;

            _dbContext.Add(entity);
            int record = await _dbContext.SaveChangesAsync();

            await _customHttpClient.UpdateUserTotalContentAsync(new UpdateUserDto(entity.Id, record * -1), token);

            return new ResultDto<ContentDto>(entity.Adapt<ContentDto>(), "Successfully created!");
        }

        public async Task<ResultDto<bool>> DeleteAsync(Guid id, CancellationToken token)
        {
            if (id == Guid.Empty)
                return new ResultDto<bool>("Id can not be null or empty!");

            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == id, token);

            if (entity == null)
                return new ResultDto<bool>("Item not found!");

            //Logic silme
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.UtcNow;

            //Gerçek silme
            //_dbContext.Remove(entity);
            int record = await _dbContext.SaveChangesAsync(token);
            if (record > 0)
            {
                await _customHttpClient.UpdateUserTotalContentAsync(new UpdateUserDto(id, record * -1), token);
                return new ResultDto<bool>(true, "Successfully deleted!");
            }
            else
                return new ResultDto<bool>("Failed!");

        }

        public async Task<ResultDto<ContentDto>> ReadAsync(Guid id, CancellationToken token)
        {
            if (id == Guid.Empty)
                return new ResultDto<ContentDto>("Id can not be null or empty!");

            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == id, token);
            return new ResultDto<ContentDto>(entity.Adapt<ContentDto>());
        }

        public async Task<ResultDto<IEnumerable<ContentDto>>> ReadAsync(CancellationToken token)
        {
            //Yukarda Logic silme yapıldığı için burada IsDelted'ların Filtrelenmesi için bir parametere iyi olacaktır
            //Ancak case içeriğine sadık kalınması açısından eklenmedi,

            var listOfEntity = await _dbContext.Contents.ToListAsync(token);
            return new ResultDto<IEnumerable<ContentDto>>(listOfEntity.Adapt<IEnumerable<ContentDto>>());
        }

        public async Task<ResultDto<ContentDto>> UpdateAsync(UpdateContentDto item, CancellationToken token)
        {
            var entity = await _dbContext.Contents.FirstOrDefaultAsync(u => u.Id == item.Id, token);
            if (entity == null)
                return new ResultDto<ContentDto>(null, "Item not found!");

            entity.Header = item.Header;
            entity.Body = item.Body;
            entity.Tags = item.Tags;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedUserId = item.UpdatedUserId;

            _dbContext.Update(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return new ResultDto<ContentDto>(entity.Adapt<ContentDto>());

        }
    }
}
