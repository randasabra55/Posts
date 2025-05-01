using FluentValidation;
using Posts_Core.Features.Postss.Commands.Models;

namespace Posts_Core.Features.Postss.Commands.Validations
{
    public class EditPostValidator : AbstractValidator<EditPostCommand>
    {
        public EditPostValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");


        }
    }
}
