using BathenyShop.Models;
using BathenyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BathenyShop.Components;

public class ShoppingCartSummary : ViewComponent
{
    private readonly IShoppingCart _cart;

    public ShoppingCartSummary(IShoppingCart cart)
    {
        _cart = cart;
    }
    public IViewComponentResult Invoke()
    {
        var items = _cart.GetShoppingCartItems();
        _cart.ShoppingCartItems = items;

        var shoppingCartView = new ShoppingCartViewModel(_cart, _cart.GetShoppingCartTotal());
        return View(shoppingCartView);
    }
}

