using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.UserAgg.GetById
{
    public class GetByIdUserQueryHandler : IBaseQueryHandler<GetByIdUserQuery, UserDto>
    {
        private readonly BlogfaContext _context;

        public GetByIdUserQueryHandler(BlogfaContext context) => _context = context;

        public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == request.Id);
            return user!.MapSingle();
        }
    }
}