﻿namespace BookShop.Infrastructure.Requests.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
