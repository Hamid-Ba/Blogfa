using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.UserAgg.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.LastName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام خانوادگی"));
        }
    }
}