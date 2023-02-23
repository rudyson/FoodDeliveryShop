using FoodDeliveryShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<IProductRepository, FakeProductRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
string connectionString = configuration.GetValue<string>("Data:FoodDeliveryShopProducts:ConnectionStrings");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});


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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=List}/{id?}");
SeedData.EnsurePopulated(app);
app.Run();
