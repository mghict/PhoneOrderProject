using FluentValidation;

namespace AccessManagment.Application.PageInfo.Validators
{
    public class GetByParentPageInfoValidator :
        FluentValidation.AbstractValidator<Commands.GetByParentPageInfoCommand>
    {
        public GetByParentPageInfoValidator() : base()
        {
            RuleFor(current => current.ParentId)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
