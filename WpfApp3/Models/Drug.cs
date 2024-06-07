using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Dosage { get; set; }
        public int ShelfLife { get; set; }
    }

}
