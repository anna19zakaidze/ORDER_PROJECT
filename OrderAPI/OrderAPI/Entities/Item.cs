﻿namespace OrderAPI.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public  string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}