﻿using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
