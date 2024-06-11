using System;

namespace WpfApp3.Models
{
    public class Stock
    {
        //объявление переменных для класса
        public int PharmacyId { get; set; }
        public int DrugId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int StockId { get; internal set; }

        public void Validate()
        {
            //Проверка на адекватность количества и цены
            if (Quantity < 1 || Quantity > 10000)
                throw new ArgumentException("Quantity must be between 1 and 10000.");
            if (Price < 0.5m || Price > 10000m)
                throw new ArgumentException("Price must be between 0.5 and 10000.");
        }
    }
}
