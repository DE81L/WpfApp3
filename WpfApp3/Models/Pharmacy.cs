using System;

namespace WpfApp3.Models
{
    public class Pharmacy
    {
        //объявление переменных для класса
        public int PharmacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public void Validate()
        {
            //простая проверка на соответствие часовому формату
            if (StartHour < 0 || StartHour > 24 || EndHour < 0 || EndHour > 24)
                throw new ArgumentException("Start and end hours must be between 0 and 24.");
        }
    }
}
