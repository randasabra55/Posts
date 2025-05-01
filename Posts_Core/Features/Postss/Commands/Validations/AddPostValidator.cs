using FluentValidation;
using Posts_Core.Features.Postss.Commands.Models;

namespace Posts_Core.Features.Postss.Commands.Validations
{
    public class AddPostValidator : AbstractValidator<AddPostCommand>
    {
        public AddPostValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Title must not be empty")
                 .NotNull().WithMessage("Title must not be null");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content must not be empty")
                .NotNull().WithMessage("Content must not be null");

            RuleFor(x => x.userId)
                .NotEmpty().WithMessage("User must not be empty")
                .NotNull().WithMessage("User must not be null");


        }
    }
}
