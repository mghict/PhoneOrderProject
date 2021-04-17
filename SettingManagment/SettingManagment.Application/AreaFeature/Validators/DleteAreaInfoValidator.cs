using FluentValidation;

namespace SettingManagment.Application.AreaFeature.Validators
{
    public class DleteAreaInfoValidator : AbstractValidator<Commands.DeleteAreaInfoCommand>
    {
        public DleteAreaInfoValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithName("کد")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .ExclusiveBetween(0, int.MaxValue)
                .WithErrorCode("9")
                .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

           

        }
    }
}
