using Blogfa.Application.UserAgg.Active;
using Blogfa.Application.UserAgg.ChangePassword;
using Blogfa.Application.UserAgg.Create;
using Blogfa.Application.UserAgg.DeActive;
using Blogfa.Application.UserAgg.Edit;
using Blogfa.Application.UserAgg.Register;
using Blogfa.Query.UserAgg.DTOs;
using Blogfa.Query.UserAgg.GetAll;
using Blogfa.Query.UserAgg.GetById;
using Blogfa.Query.UserAgg.GetByPhone;
using Framework.Application;
using MediatR;

namespace Blogfa.Presentation.Facade.UserAgg
{
    public class UserFacade : IUserFacade
	{
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Active(ActiveUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangePassword(ChangePasswordUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> DeActive(DeActiveUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditUserCommand command) => await _mediator.Send(command);

        public async Task<UserFilterResult> GetAll(UserFilterParam filter) => await _mediator.Send(new GetAllUserQuery(filter));

        public async Task<UserDto> GetBy(long id) => await _mediator.Send(new GetUserByIdQuery(id));

        public async Task<UserDto> GetBy(string phoneNumber) => await _mediator.Send(new GetUserByPhoneQuery(phoneNumber));

        public async Task<OperationResult> Register(RegisterUserCommand command) => await _mediator.Send(command);
    }
}