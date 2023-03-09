namespace FoodDeliveryShop.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}