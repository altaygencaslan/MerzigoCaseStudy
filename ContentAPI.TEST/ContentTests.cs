using ContentAPI.Business.DTOs;
using ContentAPI.Business.Repositories;

namespace ContentAPI.TEST
{
    public class ContentTests
    {
        private readonly IContentRepository _contentRepository;
        public ContentTests(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [SetUp]
        public void Setup()
        {
        }

        #region Validation - Return FALSE Tests
        [Test]
        public async Task Test_ValidationReturnFalse_ContentCreateAsync()
        {
            var createContent = await _contentRepository.CreateAsync(new CreateContentDto(), new CancellationToken());
            Assert.IsNull(createContent.Data);
            Assert.IsTrue(createContent.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentUpdateAsync()
        {
            var updateContent = await _contentRepository.UpdateAsync(new UpdateContentDto(), new CancellationToken());
            Assert.IsNull(updateContent.Data);
            Assert.IsTrue(updateContent.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentDeleteAsync()
        {
            var deleteContent = await _contentRepository.DeleteAsync(Guid.Empty, new CancellationToken());
            Assert.IsNull(deleteContent.Data);
            Assert.IsTrue(deleteContent.IsSuccess == false);
        }


        [Test]
        public async Task Test_ValidationReturnFalse_ContentReadByIdAsync()
        {
            var getContentById = await _contentRepository.ReadAsync(Guid.Empty, new CancellationToken());
            Assert.IsNull(getContentById.Data);
            Assert.IsTrue(getContentById.IsSuccess == false);
        }

        [Test]
        public async Task Test_ValidationReturnFalse_ContentReadAsync()
        {
            var getAllContents = await _contentRepository.ReadAsync(new CancellationToken());
            Assert.IsNull(getAllContents.Data);
            Assert.IsTrue(getAllContents.IsSuccess == false);
        }
        #endregion
    }
}