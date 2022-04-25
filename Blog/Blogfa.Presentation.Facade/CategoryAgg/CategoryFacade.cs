using Blogfa.Application.CategoryAgg.Create;
using Blogfa.Application.CategoryAgg.Edit;
using Blogfa.Query.CategoryAgg.DTOs;
using Blogfa.Query.CategoryAgg.GetAll;
using Blogfa.Query.CategoryAgg.GetById;
using Blogfa.Query.CategoryAgg.GetBySlug;
using Framework.Application;
using MediatR;

namespace Blogfa.Presentation.Facade.CategoryAgg
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;

        public CategoryFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Create(CreateCategoryCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditCategoryCommand command) => await _mediator.Send(command);

        public async Task<IEnumerable<CategoryDto>> GetAll() => await _mediator.Send(new GetAllCategoryQuery());

        public async Task<CategoryDto> GetBy(long id) => await _mediator.Send(new GetCategoryByIdQuery(id));

        public async Task<CategoryDto> GetBy(string slug) => await _mediator.Send(new GetCategoryBySlugQuery(slug));
        
    }
}