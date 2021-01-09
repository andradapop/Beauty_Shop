using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty_Shop.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Denumire Produs")]
        public string Denumire { get; set; }
        public string Brand { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFabricarii { get; set; }

        public int StatusID { get; set; }
        public Status Status{ get; set; }

        public ICollection<CategorieProdus> CategoriiProdus { get; set; }
    }
}
