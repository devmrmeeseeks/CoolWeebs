using CoolWebs.Model.TitleLIst;
using FluentValidation;

namespace CoolWeebs.API.Modules.TitleList.Validators
{
    public class TitleValidator : AbstractValidator<TitleRequest>
    {
        public TitleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);
        }
    }
}
