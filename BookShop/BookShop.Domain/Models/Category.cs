﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
