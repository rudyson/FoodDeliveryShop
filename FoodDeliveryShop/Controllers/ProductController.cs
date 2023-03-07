using FoodDeliveryShop.Models;
using FoodDeliveryShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository repository;
		private int productCapacityPerPage { get; set; }


		public ProductController(IProductRepository repo)
		{
			repository = repo;
			productCapacityPerPage = 4;

		}

		public IActionResult Index()
		{
			return View();
		}
		public ViewResult List(string? category, int page = 1) => View(new ProductsListViewModel
		{
			Products = category == null ?
			repository.Products
			.OrderBy(p => p.ProductID)
			.Skip((page - 1) * productCapacityPerPage)
			.Take(productCapacityPerPage)
			:
			repository.Products
			.Where(p => p.Category == null || p.Category == category)
			.OrderBy(p => p.ProductID)
			.Skip((page - 1) * productCapacityPerPage)
			.Take(productCapacityPerPage),
			PagingInfo = new PagingInfo
			{
				CurrentPage = page,
				CurrentCategory = category,
				ItemsPerPage = productCapacityPerPage,
				TotalItems = category == null ? repository.Products.Count() :
												repository.Products.Where(e =>
												e.Category == category).Count()

			}
		});
		/*View(repository.Products
					.OrderBy(p => p.ProductID)
					.Skip((page - 1)* productCapacityPerPage)
					.Take(productCapacityPerPage));*/
	}
}
