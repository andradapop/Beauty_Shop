using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty_Shop.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieProdus> CategoriiProdus { get; set; }
    }
}
