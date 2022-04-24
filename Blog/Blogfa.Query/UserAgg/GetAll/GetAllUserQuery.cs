using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.UserAgg.GetAll
{
    public class GetAllUserQuery : QueryFilter<UserFilterResult, UserFilterParam>
    {
        public GetAllUserQuery(UserFilterParam filterParams) : base(filterParams) { }
    }
}