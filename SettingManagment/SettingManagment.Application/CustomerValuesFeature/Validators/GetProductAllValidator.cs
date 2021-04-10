using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductAllValidator : AbstractValidator<Commands.GetProductsAllCommand>
    {
        public GetProductAllValidator() : base()
        {

            

        }
    }
}
