using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty_Shop.Models
{
    public class Status
    {
        public int ID { get; set; }
        public string StatusVal { get; set; }
        public ICollection<Produs> Produse { get; set; }
    }
}
