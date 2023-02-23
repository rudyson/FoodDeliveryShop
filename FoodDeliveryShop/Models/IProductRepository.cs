namespace FoodDeliveryShop.Models
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> Products { get; }
    }
}
