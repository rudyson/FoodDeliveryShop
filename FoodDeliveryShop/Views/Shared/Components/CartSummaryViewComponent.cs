using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Views.Shared.Components
{
	public class CartSummaryViewComponent : ViewComponent
	{
		private Models.Cart cart;
		public CartSummaryViewComponent(Models.Cart cartService)
		{
			cart = cartService;
		}
		public IViewComponentResult Invoke()
		{
			return View(cart);
		}
	}
}