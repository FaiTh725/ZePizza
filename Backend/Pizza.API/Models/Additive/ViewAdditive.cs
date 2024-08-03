﻿namespace Pizza.API.Models.Additive
{
    public class ViewAdditive
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
