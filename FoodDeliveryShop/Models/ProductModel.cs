using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryShop.Models
{
    public class ProductModel
    {
		[Key]
		public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
