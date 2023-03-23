namespace FoodDeliveryShop.Models
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> Products { get; }
        void SaveProduct(ProductModel product);
		ProductModel DeleteProduct(int productId);
	}
}