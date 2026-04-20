using Application.DTOs.Category;
using FluentValidation;

namespace Application.Validators.Category;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdate>
{
    public CategoryUpdateValidator()
    {
        RuleFor(c => c.Id).Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Category name is required.")
            .NotNull().WithMessage("Category name cannot be null.")
            .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.");
    }
}
