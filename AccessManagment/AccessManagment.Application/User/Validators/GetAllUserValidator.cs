using FluentValidation;

namespace AccessManagment.Application.User.Validators
{
    public class GetAllUserValidator : AbstractValidator<Commands.GetAllUserCommand>
    {
        public GetAllUserValidator() : base()
        {
            
        }
    }
}
