using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryShop.Models
{
    public class ProductModel
    {
		[Key]
		public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
