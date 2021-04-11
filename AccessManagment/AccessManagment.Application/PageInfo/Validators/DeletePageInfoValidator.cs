using FluentValidation;

namespace AccessManagment.Application.PageInfo.Validators
{
    public class DeletePageInfoValidator :
        FluentValidation.AbstractValidator<Commands.DeletePageInfoCommand>
    {
        public DeletePageInfoValidator() : base()
        {
            RuleFor(current => current.Id)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
