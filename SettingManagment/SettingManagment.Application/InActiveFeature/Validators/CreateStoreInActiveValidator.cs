using FluentValidation;

namespace SettingManagment.Application.InActiveFeature.Validators
{
    public class CreateStoreInActiveValidator : FluentValidation.AbstractValidator<Commands.CreateStoreInActiveCommand>
    {
        public CreateStoreInActiveValidator() : base()
        {

            RuleFor(current => current.FromDate)
                .NotEmpty()
                .WithName("تاریخ شروع")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.ToDate)
                .NotEmpty()
                .WithName("تاریخ پایان")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.Title)
                .NotEmpty()
                .WithName("عنوان")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("فروشگاه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}
