using Blogfa.Application.UserAgg.Active;
using Blogfa.Application.UserAgg.ChangePassword;
using Blogfa.Application.UserAgg.Create;
using Blogfa.Application.UserAgg.DeActive;
using Blogfa.Application.UserAgg.Edit;
using Blogfa.Application.UserAgg.Register;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Application;

namespace Blogfa.Presentation.Facade.UserAgg
{
    public interface IUserFacade
	{
        #region Commands
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> Active(ActiveUserCommand command);
        Task<OperationResult> DeActive(DeActiveUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> ChangePassword(ChangePasswordUserCommand command);
        #endregion

        #region Queries
        Task<UserDto> GetBy(long id);
        Task<UserDto> GetBy(string phoneNumber);
        Task<UserFilterResult> GetAll(UserFilterParam filter);
        #endregion
    }
}