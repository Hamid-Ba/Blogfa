using Blogfa.Presentation.Facade.CategoryAgg;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class CategoryApiController : BaseApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryApiController(ICategoryFacade categoryFacade) => _categoryFacade = categoryFacade;

        [HttpGet]
        public async Task<ApiResult<IEnumerable<CategoryDto>>> GetAll() => QueryResult(await _categoryFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetBy(long id) => QueryResult(await _categoryFacade.GetBy(id));

        [HttpGet("{slug}")]
        public async Task<ApiResult<CategoryDto>> GetBy(string slug) => QueryResult(await _categoryFacade.GetBy(slug));
    }
}