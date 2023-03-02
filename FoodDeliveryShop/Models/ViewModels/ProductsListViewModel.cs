namespace FoodDeliveryShop.Models.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<ProductModel>? Products { get; set; }
		public PagingInfo? PagingInfo { get; set; }
	}
}