using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
