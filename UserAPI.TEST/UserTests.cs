using UserAPI.Business.DTOs;
using UserAPI.Business.Repositories;

namespace UserAPI.TEST
{
    public class UserTests
    {
        private readonly IUserRepository _userRepository;
        public UserTests(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [SetUp]
        public void Setup()
        {
        }

        #region Validation - Return FALSE Tests
        [Test]
        public async Task Test_ValidationReturnFalse_ContentCreateAsync()
        {
            var createUser = await _userRepository.CreateAsync(new CreateUserDto(), new CancellationToken());
            Assert.IsNull(createUser.Data);
            Assert.IsTrue(createUser.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentUpdateAsync()
        {
            var updateUser = await _userRepository.UpdateAsync(new UpdateUserDto(), new CancellationToken());
            Assert.IsNull(updateUser.Data);
            Assert.IsTrue(updateUser.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentDeleteAsync()
        {
            var deleteUser = await _userRepository.DeleteAsync(Guid.Empty, new CancellationToken());
            Assert.IsNull(deleteUser.Data);
            Assert.IsTrue(deleteUser.IsSuccess == false);
        }


        [Test]
        public async Task Test_ValidationReturnFalse_ContentReadByIdAsync()
        {
            var getUserById = await _userRepository.ReadAsync(Guid.Empty, new CancellationToken());
            Assert.IsNull(getUserById.Data);
            Assert.IsTrue(getUserById.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentReadAsync()
        {
            var getAllUsers = await _userRepository.ReadAsync(new CancellationToken());
            Assert.IsNull(getAllUsers.Data);
            Assert.IsTrue(getAllUsers.IsSuccess == false);
        }
        #endregion
    }
}