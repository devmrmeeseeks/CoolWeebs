using CoolWebs.Model.TitleLIst;
using FluentValidation;

namespace CoolWeebs.API.Modules.TitleList.Validators
{
    public class ListValidator : AbstractValidator<ListRequest>
    {
        public ListValidator()
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
