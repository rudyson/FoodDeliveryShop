namespace FoodDeliveryShop.Models
{
	public class EFProductRepository : IProductRepository
	{
		public IEnumerable<ProductModel> Products => context.Product;

		private ApplicationDbContext context;

		public EFProductRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}
        public void SaveProduct(ProductModel product)
        {
            if (product.ProductID == 0)
            {
                context.Product.Add(product);
            }
            else
            {
                ProductModel? dbEntry = context.Product.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
		public ProductModel DeleteProduct(int productID)
		{
			ProductModel? dbEntry = context.Product.FirstOrDefault(p => p.ProductID == productID);
			if (dbEntry != null)
			{
				context.Product.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}

	}
}