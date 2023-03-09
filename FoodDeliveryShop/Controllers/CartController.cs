using FoodDeliveryShop.Models;
using FoodDeliveryShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Controllers
{
	public class CartController : Controller
	{
		private IProductRepository repository;
		private Cart cart;
		public CartController(IProductRepository repo, Cart cartService)
		{
			this.repository = repo;
			this.cart = cartService;
		}
		public ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = this.cart,
				ReturnUrl = returnUrl
			});
		}
		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			ProductModel? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
			if (product != null)
			{
				this.cart.AddItem(product, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
		{
			ProductModel? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
			if (product != null)
			{
				this.cart.RemoveLine(product);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public RedirectToActionResult Clear(string returnUrl)
		{
			this.cart.Clear();
			return RedirectToAction("Index", new { returnUrl });
		}
	}
}
