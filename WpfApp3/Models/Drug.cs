using System;

namespace WpfApp3.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Dosage { get; set; }
        public int ShelfLife { get; set; }

        public void Validate()
        {
            if (ShelfLife < 1 || ShelfLife > 1000)
                throw new ArgumentException("Shelf life must be between 1 and 1000 days.");
        }
    }
}
