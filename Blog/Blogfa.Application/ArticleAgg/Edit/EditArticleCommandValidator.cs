using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Blogfa.Application.ArticleAgg.Edit
{
    public class EditArticleCommandValidator  : AbstractValidator<EditArticleCommand>
    {
        public EditArticleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("title"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("slug"));

            RuleFor(r => r.Description)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("description"));

            RuleFor(r => r.ImageFile)
                .JustImageFile();
        }
    }
}