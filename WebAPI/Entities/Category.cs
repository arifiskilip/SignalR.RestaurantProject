﻿using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
