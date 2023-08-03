using FluentValidation;
using POS.Application.Dtos.Request;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator: AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The Name field can't be null.")
                .NotEmpty().WithMessage("The Name field can't be blank.");
        }
    }
}
