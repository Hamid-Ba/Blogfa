using Framework.Query;

namespace Blogfa.Query.CommentAgg.DTOs
{
    public class CommentDto : BaseDto
	{
		public long UserId { get;  set; }
        public string UserFullName { get; set; }
        public string UserPhone { get; set; }
        public long ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Content { get; set; }
		public bool IsConfirm { get; set; }
	}
}