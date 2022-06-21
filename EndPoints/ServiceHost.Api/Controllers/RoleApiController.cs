using Blogfa.Presentation.Facade.RoleAgg;
using Blogfa.Query.RoleAgg.DTOs;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class RoleApiController : BaseApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleApiController(IRoleFacade roleFacade) => _roleFacade = roleFacade;

        [HttpGet]
        public async Task<ApiResult<IEnumerable<RoleDto>>> GetAll() => QueryResult(await _roleFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<RoleDto>> GetBy(long id) => QueryResult(await _roleFacade.GetBy(id));
    }
}