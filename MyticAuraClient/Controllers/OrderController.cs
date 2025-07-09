using Microsoft.AspNetCore.Mvc;
using MyticAuraClient.DTOs.Order;
using MyticAuraClient.DTOs.Orderdetail;
using MyticAuraClient.Service.Interface;

namespace MyticAuraClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IOrderdetailService _orderdetailService;
        private readonly Guid _userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        public OrderController(IOrderService orderService, ICartService cartService, IOrderdetailService orderdetailService)
        {
            _orderService = orderService;
            _cartService = cartService;
            _orderdetailService = orderdetailService;

        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersByUserAsync(_userId);
            return View(orders);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new CreateOrderDto());
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CreateOrderDto dto)
        {
            // Thêm giả lập lấy OrderDetails từ giỏ hàng (ví dụ gọi CartService hoặc Session)
            var cartItems = await _cartService.GetUserCartAsync(); // userId cố định test
            dto.OrderDetails = cartItems.Select(c => new CreateOrderDetailDto
            {
                ProductId = c.ProductId,
                Size = c.Size,
                Quantity = c.Quantity,
                Price = c.UnitPrice
            }).ToList();

            await _orderService.CreateOrderAsync(dto);

            // Xóa giỏ hàng sau khi đặt
            await _cartService.ClearCartAsync();

            return RedirectToAction("Index", "Order");
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _orderService.CancelOrderAsync(id);
            TempData["message"] = "Đã hủy đơn hàng";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(Guid id)
        {
            await _orderService.ConfirmOrderAsync(id);
            TempData["message"] = "Đã xác nhận đơn hàng hoàn thành";
            return RedirectToAction("Index");
        }

        [HttpGet("Order/Details/{orderId}")]
        public async Task<IActionResult> Details(Guid orderId)
        {
            var details = await _orderdetailService.GetByOrderIdAsync(orderId);
            ViewBag.OrderId = orderId;
            return View(details);
        }

    }
}