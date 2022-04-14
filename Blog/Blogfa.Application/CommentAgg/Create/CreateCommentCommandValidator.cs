using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.CommentAgg.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(r => r.Content)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("محتوا"));
        }
    }
}