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
                          .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("اسلاگ"));

            RuleFor(r => r.Description)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.ImageFile)
                .JustImageFile();
        }
    }
}