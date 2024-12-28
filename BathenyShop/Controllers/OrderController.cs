using BathenyShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BathenyShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository , IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart  = shoppingCart;
        }

        // by default this will be considered GET
        public IActionResult Checkout()
        {
            return View();
        }


        // this is the post method of the form 
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items =  _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.Message = "Thank you for your order!";
            return View();
        }
    }
}
