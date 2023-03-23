namespace FoodDeliveryShop.Models
{
    public class FakeProductRepository// : IProductRepository
    {
        private IEnumerable<ProductModel>? _products;
        public IEnumerable<ProductModel> Products => _products ??= new List<ProductModel>()
        {
            new ProductModel { Name = "Pizza", Price = 10 },
            new ProductModel { Name = "Burger", Price = 15 },
            new ProductModel { Name = "Sandwich", Price = 5 },
            new ProductModel {Name = "Sushi", Price = 18},
            new ProductModel {Name = "Tabasco", Price = 8},
            new ProductModel {Name = "Hot Dog", Price = 7},
            new ProductModel {Name = "Shawarma", Price = 12}
        };

    }
}
