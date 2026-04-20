using Application.DTOs.Menu;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators.Menu;

public class MenuUpdateValidator : AbstractValidator<MenuUpdate>
{
    private readonly ICategoryService _categoryService;
    public MenuUpdateValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        RuleFor(c => c.Id).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o id do cardapio.")
            .NotNull().WithMessage("Digite o id do cardapio.");
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o nome do cardapio.")
            .NotNull().WithMessage("Digite o nome do cardapio.")
            .MinimumLength(3).WithMessage("Cardapio precisa de 3 letras.")
            .MaximumLength(100).WithMessage("Cardapio só pode ter 100 letras.");
        RuleFor(c => c.CategoryId).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o id da categoria.")
            .NotNull().WithMessage("Digite o id da categoria.")
            .Must(categoryId => MenuValidatorAll.CategoryIdExists(categoryId, _categoryService)).WithMessage("Categoria não encontrada.");

        RuleFor(c => c.Value).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o preço do cardapio.")
            .NotNull().WithMessage("Digite o preço do cardapio.")
            .GreaterThan(0).WithMessage("Preço do cardapio precisa ser maior que 0.");
    }
}
