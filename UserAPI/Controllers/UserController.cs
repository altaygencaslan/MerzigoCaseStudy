using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Business.DTOs;
using UserAPI.Business.Repositories;

namespace UserAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto item, CancellationToken token)
        {
            var result = await _userRepository.CreateAsync(item, token);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserDto item, CancellationToken token)
        {
            var result = await _userRepository.UpdateAsync(item, token);
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken token)
        {
            var result = await _userRepository.ReadAsync(id, token);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken token)
        {
            var result = await _userRepository.ReadAsync(token);
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _userRepository.DeleteAsync(id, token);
            return Ok(result);
        }
    }
}
