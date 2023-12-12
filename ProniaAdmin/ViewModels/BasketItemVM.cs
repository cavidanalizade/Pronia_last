namespace ProniaAdmin.ViewModels
{
	public class BasketItemVM
	{
		public int Id { get; set; }
		public int? Count { get; set; }
		public double Price { get; set; }
        public string? Name { get; set; }
		public string? ImgUrl { get; set; }

		public string? Description { get; set; }

    }
}
