using Microsoft.AspNetCore.Mvc;
using MyticAuraClient.DTOs.Cart;
using MyticAuraClient.Service.Interface;

namespace MyticAuraClient.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetUserCartAsync();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCartDto dto)
        {
            await _cartService.AddToCartAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid cartId)
        {
            await _cartService.DeleteCartItemAsync(cartId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid cartId, [FromForm] int Quantity, [FromForm] string Size)
        {
            var dto = new UpdateCartDto
            {
                Quantity = Quantity,
                Size = Size
            };
            await _cartService.UpdateCartAsync(cartId, dto);
            return RedirectToAction("Index");
        }

    }
}