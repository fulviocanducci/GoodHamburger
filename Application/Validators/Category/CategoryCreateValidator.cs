using Application.DTOs.Category;
using FluentValidation;

namespace Application.Validators.Category;

public class CategoryCreateValidator : AbstractValidator<CategoryCreate>
{
    public CategoryCreateValidator()
    {
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Category name is required.")
            .NotNull().WithMessage("Category name cannot be null.")
            .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.");
    }
}
