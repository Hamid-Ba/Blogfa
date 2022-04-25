using Blogfa.Application.CommentAgg.Confirm;
using Blogfa.Application.CommentAgg.Create;
using Blogfa.Application.CommentAgg.Reject;
using Blogfa.Query.CommentAgg.DTOs;
using Framework.Application;

namespace Blogfa.Presentation.Facade.CommentAgg
{
    public interface ICommentFacade
	{
        #region Commands
        Task<OperationResult> Create(CreateCommentCommand command);
        Task<OperationResult> Reject(RejectCommentCommand command); 
        Task<OperationResult> Confirm(ConfirmCommentCommand command);
        #endregion

        #region Queries
        Task<CommentDto> GetBy(long id);
        Task<CommentFilterResult> GetAll(CommentFilterParam filter);
        #endregion
    }
}