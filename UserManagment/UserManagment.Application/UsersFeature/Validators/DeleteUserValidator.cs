using FluentValidation;

namespace UserManagment.Application.UsersFeature.Validators
{
    public class DeleteUserValidator :
        FluentValidation.AbstractValidator<Commands.DeleteUserCommand>
    {
        public DeleteUserValidator() : base()
        {
            
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