using Application.DTOs.Order;
using Application.Interfaces;
using Shared.Constants;

namespace Application.Validators.Order;

public static class OrderValidatorAll
{
    public static bool OrderItemsRules(List<OrderItemCreate> orderItems, IMenuService menuService)
    {
        int countSandwich = 0;
        int countPotatoes = 0;
        int countDrink = 0;
        foreach (OrderItemCreate item in orderItems)
        {
            if (!menuService.IsIdExist(item.MenuId))
            {
                countSandwich = 0;
                countPotatoes = 0;
                countDrink = 0;
                break;
            }
            if (menuService.IsIdAndCategoryNameExist(item.MenuId, MenuConstant.SandwichCategory))
            {
                countSandwich++;
            }
            else if (menuService.IsIdAndCategoryNameExist(item.MenuId, MenuConstant.PotatoesCategory))
            {
                countPotatoes++;
            }
            else if (menuService.IsIdAndCategoryNameExist(item.MenuId, MenuConstant.DrinkCategory))
            {
                countDrink++;
            }
        }
        return countSandwich == 1
            && countPotatoes <= 1
            && countDrink <= 1;
    }
}