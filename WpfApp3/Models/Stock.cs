﻿using System;

namespace WpfApp3.Models
{
    public class Stock
    {
        public int PharmacyId { get; set; }
        public int DrugId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            if (Quantity < 1 || Quantity > 10000)
                throw new ArgumentException("Quantity must be between 1 and 10000.");
            if (Price < 0.5m || Price > 10000m)
                throw new ArgumentException("Price must be between 0.5 and 10000.");
        }
    }
}