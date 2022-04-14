using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.CategoryAgg.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("title"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("slug"));
        }
    }
}