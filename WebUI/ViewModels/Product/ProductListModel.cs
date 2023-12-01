﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Product
{
	public class ProductListModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool ProductStatus { get; set; }
	}
}
