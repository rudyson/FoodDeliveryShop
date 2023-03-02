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
        public ViewResult List(int page = 1) => View(new ProductsListViewModel
		{
			Products = repository.Products
					 .OrderBy(p => p.ProductID)
					 .Skip((page - 1) * productCapacityPerPage)
					 .Take(productCapacityPerPage),
			PagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = productCapacityPerPage,
				TotalItems = repository.Products.Count()
			}
		});
		/*View(repository.Products
					.OrderBy(p => p.ProductID)
					.Skip((page - 1)* productCapacityPerPage)
					.Take(productCapacityPerPage));*/
	}
}
