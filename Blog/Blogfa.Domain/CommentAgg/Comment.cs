using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Blogfa.Domain.CommentAgg
{
    public class Comment : AggregateRoot
	{
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Content { get; private set; }
        public bool IsConfirm { get; private set; }

        public Comment(long userId, long productId, string content)
        {
            Guard(content);

            UserId = userId;
            ProductId = productId;
            Content = content;
            IsConfirm = false;
        }

        public void Confirm() => IsConfirm = true;
        public void Reject() => IsConfirm = false;

        public void Guard(string content) => NullOrEmptyDomainDataException.CheckString(content, nameof(content));

    }
}