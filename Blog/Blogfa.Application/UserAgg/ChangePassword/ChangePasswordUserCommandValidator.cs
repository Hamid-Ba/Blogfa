using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.UserAgg.ChangePassword
{
    public class ChangePasswordUserCommandValidator : AbstractValidator<ChangePasswordUserCommand>
    {
        public ChangePasswordUserCommandValidator()
        {

            RuleFor(r => r.Password)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(4)
                .WithMessage("حداقل رمز عبور 4 کاراکتر هست");
        }
    }
}