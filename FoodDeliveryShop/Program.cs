using FoodDeliveryShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#region Builder configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<IProductRepository, FakeProductRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();

// Registering of services for the shopping cart
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

string connectionStringProducts = configuration.GetValue<string>("Data:FoodDeliveryShopProducts:ConnectionStrings");
string connectionStringIdentity = configuration.GetValue<string>("Data:FoodDeliveryShopIdentity:ConnectionStrings");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(connectionStringProducts);
});

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
	options.UseSqlServer(connectionStringIdentity);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddMemoryCache();
builder.Services.AddSession();

#endregion

#region App configuration

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseSession();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute("pagination", "Products/Page{page}", new { Controller = "Product", Action = "List" });

app.UseMvc(routes =>
{
	routes.MapRoute(
	name: null,
	template: "{category}/Page{page:int}",
	defaults: new
	{
		controller = "Product",
		action = "List"
	});

	routes.MapRoute(
	name: null,
	template: "Page{page:int}",
	defaults: new
	{
		controller = "Product",
		action = "List",
		page = 1
	});

	routes.MapRoute(
	name: null,
	template: "{category}",
	defaults: new
	{
		controller = "Product",
		action = "List",
		page = 1
	});

	routes.MapRoute(
	name: null,
	template: "",
	defaults: new
	{
		controller = "Product",
		action = "List",
		page = 1
	});

	routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");

});

/*
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=List}/{id?}");*/
SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);
app.Run();

#endregion