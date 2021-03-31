using FluentValidation;

namespace UserManagment.Application.UsersFeature.Validators
{
    public class UpdateUserValidator :
        FluentValidation.AbstractValidator<Commands.UpdateUserCommand>
    {
        public UpdateUserValidator() : base()
        {
            RuleFor(current => current.UserName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.FirstName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.LastName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.Status)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .ExclusiveBetween((byte)0,byte.MaxValue)
                .WithErrorCode("13")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorValueFluent);

            RuleFor(current => current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .ExclusiveBetween(0, int.MaxValue)
                .WithErrorCode("13")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorValueFluent);

            
        }
    }
}