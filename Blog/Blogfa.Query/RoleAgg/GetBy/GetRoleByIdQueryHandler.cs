using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.RoleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.RoleAgg.GetBy
{
    public class GetRoleByIdQueryHandler : IBaseQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly BlogfaContext _context;

        public GetRoleByIdQueryHandler(BlogfaContext context) => _context = context;

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Role.FirstOrDefaultAsync(r => r.Id == request.Id);
            return role!.Map();
        }
    }
}