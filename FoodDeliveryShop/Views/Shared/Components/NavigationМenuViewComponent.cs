using FoodDeliveryShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Components
{
	public class NavigationМenuViewComponent : ViewComponent
	{
		private IProductRepository repository;

		public NavigationМenuViewComponent(IProductRepository repo)
		{
			repository = repo;
		}

		public IViewComponentResult Invoke() {
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(
				repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x));
		} 
	}
}
