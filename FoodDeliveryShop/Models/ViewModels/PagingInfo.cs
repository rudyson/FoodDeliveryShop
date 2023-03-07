namespace FoodDeliveryShop.Models.ViewModels
{
	public class PagingInfo
	{
		public int TotalItems { get; set; }
		public int ItemsPerPage { get; set; }
		public string? CurrentCategory { get; set; }
		public int CurrentPage { get; set; }
		public int PreviousPage => (CurrentPage > 2) ? CurrentPage - 1 : 1;
		public int NextPage => (CurrentPage < TotalPages) ? CurrentPage + 1 : TotalPages;
		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
	}
}