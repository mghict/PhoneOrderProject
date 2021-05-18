using FluentValidation;

namespace SettingManagment.Application.InActiveFeature.Validators
{
    public class EditStoreInActiveValidator : FluentValidation.AbstractValidator<Commands.EditStoreInActiveCommand>
    {
        public EditStoreInActiveValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithName("کد")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

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

            RuleFor(current => current.Status)
                .NotEmpty()
                .WithName("وضعیت")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}
