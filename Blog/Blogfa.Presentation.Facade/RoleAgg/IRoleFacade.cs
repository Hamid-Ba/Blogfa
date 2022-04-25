using Blogfa.Application.RoleAgg.Create;
using Blogfa.Application.RoleAgg.Edit;
using Blogfa.Query.RoleAgg.DTOs;
using Framework.Application;

namespace Blogfa.Presentation.Facade.RoleAgg
{
    public interface IRoleFacade
	{
        #region Commands
        Task<OperationResult> Edit(EditRoleCommand command);
        Task<OperationResult> Create(CreateRoleCommand command);
        #endregion

        #region Queries
        Task<RoleDto> GetBy(long id);
        Task<IEnumerable<RoleDto>> GetAll();
        #endregion
    }
}

