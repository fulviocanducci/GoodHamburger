using Application.DTOs.Order;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators.Order;

public class OrderCreateValidator : AbstractValidator<OrderCreate>
{
    private readonly IMenuService _menuService;

    public OrderCreateValidator(IMenuService menuService)
    {
        _menuService = menuService;
        RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Digite o nome do cliente");
        RuleFor(x => x.OrderItems).Cascade(CascadeMode.Stop)
            .NotNull().Must(x => x.Count >= 1).WithMessage("Deve conter pelo menos um item.")
            .Must(x => OrderValidatorAll.OrderItemsRules(x, _menuService)).WithMessage("Item(s) do pedido é/são inválido(s), obrigatório 1 sanduíche e no máximo 1 batata e/ou 1 bebida.");
    }
}