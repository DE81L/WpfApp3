using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Stock
    {
        public int PharmacyId { get; set; }
        public int DrugId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}
