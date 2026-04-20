using Application.DTOs.Category;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators.Category;

public class CategoryCreateValidator : AbstractValidator<CategoryCreate>
{
    private readonly ICategoryService _categoryService;

    public CategoryCreateValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o nome da categoria.")
            .NotNull().WithMessage("Digite o nome da categoria.")
            .MinimumLength(3).WithMessage("Categoria precisa de 3 letras.")
            .MaximumLength(50).WithMessage("Categoria só pode ter 50 letras.")
            .Must(name => CategoryValidadorAll.BeUniqueName(name, _categoryService)).WithMessage("Categoria já existe.");
    }
}
