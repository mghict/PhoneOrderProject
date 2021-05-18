using FluentValidation;

namespace SettingManagment.Application.InActiveFeature.Validators
{
    public class GetAllStoreInActiveValidator : FluentValidation.AbstractValidator<Commands.GetAllStoreInActiveCommand>
    {
        public GetAllStoreInActiveValidator() : base()
        {

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("کد فروشگاه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);


        }
    }
}
