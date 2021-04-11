using FluentValidation;

namespace AccessManagment.Application.PageInfo.Validators
{
    public class GetByApplicationPageInfoValidator :
        FluentValidation.AbstractValidator<Commands.GetByApplicationPageInfoCommand>
    {
        public GetByApplicationPageInfoValidator() : base()
        {
            RuleFor(current => current.ApplicationId)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
