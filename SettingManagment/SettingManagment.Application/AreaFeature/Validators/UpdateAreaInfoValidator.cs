using FluentValidation;

namespace SettingManagment.Application.AreaFeature.Validators
{
    public class UpdateAreaInfoValidator : AbstractValidator<Commands.UpdateAreaInfoCommand>
    {
        public UpdateAreaInfoValidator() : base()
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

            //RuleFor(current => current.ParentID)
            //    .NotEmpty()
            //    .WithName("کد پدر")
            //    .WithErrorCode("10")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            //    .NotNull()
            //    .WithErrorCode("11")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            //    .ExclusiveBetween(0, int.MaxValue)
            //    .WithErrorCode("9")
            //    .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.AreaName)
                .NotEmpty()
                .WithName("نام")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.AreaType)
                .NotEmpty()
                .WithName("نوع")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.CityId)
                .NotEmpty()
                .WithName("شهر")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
