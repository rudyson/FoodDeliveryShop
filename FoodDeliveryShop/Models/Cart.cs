namespace FoodDeliveryShop.Models
{
    public class Cart
    {
        public Cart()
        {
            LineCollection = new List<CartLine>();
        }

        private List<CartLine> LineCollection { get; set; }
        public virtual void AddItem(ProductModel product, int quantity)
        {
            CartLine? line = LineCollection.FirstOrDefault(p => p.Product.ProductID == product.ProductID);
            if (line == null)
            {
                LineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(ProductModel product) => LineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTotalValue() => LineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => LineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => LineCollection;
    }

}
