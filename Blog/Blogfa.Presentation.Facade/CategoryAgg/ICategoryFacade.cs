using Blogfa.Application.CategoryAgg.Create;
using Blogfa.Application.CategoryAgg.Edit;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Application;

namespace Blogfa.Presentation.Facade.CategoryAgg
{
    public interface ICategoryFacade
	{
        #region Commands
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult> Create(CreateCategoryCommand command);
        #endregion

        #region Queries
        Task<CategoryDto> GetBy(long id);
        Task<CategoryDto> GetBy(string slug);
        Task<IEnumerable<CategoryDto>> GetAll();
        #endregion
    }
}