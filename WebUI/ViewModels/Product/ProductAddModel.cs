using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Product
{
	public class ProductAddModel
	{
		[Required(ErrorMessage = "Ürün adı zorunlu!")]
		[MinLength(3, ErrorMessage = "En az 3 karakter olmak zorunda!")]
		[MaxLength(50, ErrorMessage = "En fazla 50 karakter olmak zorunda!")]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "Açıklama alanı zorunlu!")]
		[MinLength(3, ErrorMessage = "En az 3 karakter olmak zorunda!")]
		[MaxLength(50, ErrorMessage = "En fazla 50 karakter olmak zorunda!")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Fiyat zorunlu!")]
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int CategoryId { get; set; }
		public bool Status { get; set; } = true;
    }
}
