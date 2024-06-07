using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Pharmacy
    {
        public int PharmacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }

}
