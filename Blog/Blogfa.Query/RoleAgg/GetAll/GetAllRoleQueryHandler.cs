using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.RoleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.RoleAgg.GetAll
{
    public class GetAllRoleQueryHandler : IBaseQueryHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly BlogfaContext _context;

        public GetAllRoleQueryHandler(BlogfaContext context) => _context = context;

        public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Role.OrderByDescending(o => o.Id).ToListAsync();
            return roles.Select(r => r.Map()).ToList();
        }
    }
}