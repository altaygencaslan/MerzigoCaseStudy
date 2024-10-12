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
    }
}
