using Blogfa.Application.RoleAgg.Create;
using Blogfa.Application.RoleAgg.Edit;
using Blogfa.Query.RoleAgg.DTOs;
using Blogfa.Query.RoleAgg.GetAll;
using Blogfa.Query.RoleAgg.GetBy;
using Framework.Application;
using MediatR;

namespace Blogfa.Presentation.Facade.RoleAgg
{
    public class RoleFacade : IRoleFacade
    {
        private readonly IMediator _mediator;

        public RoleFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Create(CreateRoleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditRoleCommand command) => await _mediator.Send(command);

        public async Task<IEnumerable<RoleDto>> GetAll() => await _mediator.Send(new GetAllRoleQuery());

        public async Task<RoleDto> GetBy(long id) => await _mediator.Send(new GetRoleByIdQuery(id));
    }
}