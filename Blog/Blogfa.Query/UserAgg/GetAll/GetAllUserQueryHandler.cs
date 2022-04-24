using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.UserAgg.GetAll
{
    public class GetAllUserQueryHandler : IBaseQueryHandler<GetAllUserQuery, UserFilterResult>
    {
        private readonly BlogfaContext _context;

        public GetAllUserQueryHandler(BlogfaContext context) => _context = context;

        public async Task<UserFilterResult> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var users =  _context.User.OrderByDescending(o => o.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.FullName))
                users = users.Where(u => $"{u.FirstName} {u.LastName}".Contains(@params.FullName));

            if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
                users = users.Where(u => u.PhoneNumber.Contains(@params.PhoneNumber));

            var skip = (@params.PageId - 1) * @params.Take;

            var result = new UserFilterResult
            {
                FilterParams = @params,
                Data = await users.Select(u => u.Map()).ToListAsync()
            };

            result.GeneratePaging(users, @params.Take, @params.PageId);
            return result;
        }
    }
}