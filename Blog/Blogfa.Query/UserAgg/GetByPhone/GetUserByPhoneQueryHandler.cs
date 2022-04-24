using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.UserAgg.GetByPhone
{
    public class GetUserByPhoneQueryHandler : IBaseQueryHandler<GetUserByPhoneQuery, UserDto>
    {
        private readonly BlogfaContext _context;

        public GetUserByPhoneQueryHandler(BlogfaContext context) => _context = context;

        public async Task<UserDto> Handle(GetUserByPhoneQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            return user!.MapSingle();
        }
    }
}