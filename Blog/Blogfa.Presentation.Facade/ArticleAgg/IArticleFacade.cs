using System;
using Blogfa.Application.ArticleAgg.AddView;
using Blogfa.Application.ArticleAgg.ChangeStatus;
using Blogfa.Application.ArticleAgg.Create;
using Blogfa.Application.ArticleAgg.DisLike;
using Blogfa.Application.ArticleAgg.Edit;
using Blogfa.Application.ArticleAgg.Like;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Application;

namespace Blogfa.Presentation.Facade.ArticleAgg
{
	public interface IArticleFacade
	{
        #region Commands
        Task<OperationResult> Edit(EditArticleCommand command);
        Task<OperationResult> Like(LikeArticleCommand command);
        Task<OperationResult> Create(CreateArticleCommand command);
        Task<OperationResult> AddView(AddViewArticleCommand command);
        Task<OperationResult> DisLike(DisLikeArticleCommand command);
        Task<OperationResult> ChangeStatus(ChangeStatusArticleCommand command);
        #endregion

        #region Queries
        Task<ArticleDto> GetBy(long id);
        Task<ArticleDto> GetBy(string slug);
        Task<ArticleFilterResult> GetAll(ArticleFilterParam filter);
        #endregion
    }
}