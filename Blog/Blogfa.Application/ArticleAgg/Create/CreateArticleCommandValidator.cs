﻿using FluentValidation;
using Framework.Application.Validation;

namespace Blogfa.Application.ArticleAgg.Create
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("اسلاگ"));

            RuleFor(r => r.Description)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}