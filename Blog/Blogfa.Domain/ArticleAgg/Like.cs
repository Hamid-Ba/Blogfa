using Framework.Domain;

namespace Blogfa.Domain.ArticleAgg
{
    public class Like : BaseEntity
	{
        public long ArticleId { get;internal set; }
        public long UserId { get; private set; }

        public Like(long userId) => UserId = userId;
    }
}