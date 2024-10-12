﻿using ContentAPI.Business.DTOs;
using ContentAPI.Domain;
using Helper.Classes;
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

        public async Task<ResultDto<ContentDto>> CreateAsync(CreateContentDto item, CancellationToken token)
        {
            var entity = item.Adapt<Content>();
            entity.CreatedDate = DateTime.Now;

            _dbContext.Add(entity);
            int record = await _dbContext.SaveChangesAsync();

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
            entity.UpdatedDate = DateTime.Now;

            //Gerçek silme
            //_dbContext.Remove(entity);
            int record = await _dbContext.SaveChangesAsync(token);
            if (record > 0)
                return new ResultDto<bool>(true, "Successfully deleted!");
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
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedUserId = item.UpdatedUserId;

            _dbContext.Update(entity);
            int record = await _dbContext.SaveChangesAsync(token);

            return new ResultDto<ContentDto>(entity.Adapt<ContentDto>());

        }
    }
}
