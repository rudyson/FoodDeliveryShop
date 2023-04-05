using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryShop.Models
{
	public class IdentitySeedData
	{
		private const string adminUser = "admin";
		private const string adminPassword = "IAmAdmin1000-7";
		public static async void EnsurePopulated(IApplicationBuilder app)
		{
			UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
			IdentityUser user = await userManager.FindByIdAsync(adminUser);
			if (user == null)
			{
				user = new IdentityUser("Admin");
				await userManager.CreateAsync(user, adminPassword);
			}
		}
	}
}