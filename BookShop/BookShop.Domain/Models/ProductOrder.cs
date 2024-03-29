﻿namespace BookShop.Domain.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Amount { get; set; } = 1;
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
