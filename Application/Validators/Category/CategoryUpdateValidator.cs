using Application.DTOs.Category;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators.Category;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdate>
{
    private readonly ICategoryService _categoryService;
    public CategoryUpdateValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        RuleFor(c => c.Id).Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o nome da categoria.")
            .NotNull().WithMessage("Digite o nome da categoria.")
            .MinimumLength(3).WithMessage("Categoria precisa de 3 letras.")
            .MaximumLength(50).WithMessage("Categoria só pode ter 50 letras.")
            .Must(name => CategoryValidadorAll.BeUniqueName(name, _categoryService)).WithMessage("Categoria já existe.");
    }
}
