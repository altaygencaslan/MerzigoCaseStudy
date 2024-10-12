using ContentAPI.Business.DTOs;
using ContentAPI.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        public ContentController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateContentDto item, CancellationToken token)
        {
            var result = await _contentRepository.CreateAsync(item, token);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateContentDto item, CancellationToken token)
        {
            var result = await _contentRepository.UpdateAsync(item, token);
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken token)
        {
            var result = await _contentRepository.ReadAsync(id, token);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken token)
        {
            var result = await _contentRepository.ReadAsync(token);
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _contentRepository.DeleteAsync(id, token);
            return Ok(result);
        }

    }
}
