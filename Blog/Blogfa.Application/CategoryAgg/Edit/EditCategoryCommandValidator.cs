using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.CategoryAgg.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
               .NotNull().NotEmpty()
               .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("اسلاگ"));
        }
    }
}