using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.ArticleAgg.ChangeStatus
{
    public class ChangeStatusArticleCommandValidator : AbstractValidator<ChangeStatusArticleCommand>
    {
        public ChangeStatusArticleCommandValidator()
        {
            RuleFor(r => r.StatusDescription)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("دلیل"));
        }
    }
}