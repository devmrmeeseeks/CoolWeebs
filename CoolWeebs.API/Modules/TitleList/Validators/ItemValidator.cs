using CoolWebs.Model.TitleLIst;
using FluentValidation;

namespace CoolWeebs.API.Modules.TitleList.Validators
{
    public class ItemValidator : AbstractValidator<ItemRequest>
    {
        public ItemValidator()
        {
            RuleFor(x => x.TitleId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ListId)
                .NotEmpty()
                .NotNull();
        }
    }
}
