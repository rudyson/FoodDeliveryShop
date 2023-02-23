using Microsoft.EntityFrameworkCore;
namespace FoodDeliveryShop.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<ProductModel> Product { get; set; }

	}
}
