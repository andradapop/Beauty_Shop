using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beauty_Shop.Data;
using Beauty_Shop.Models;

namespace Beauty_Shop.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public IndexModel(Beauty_Shop.Data.Beauty_ShopContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ProdusD = new ProdusData();
            ProdusD.Produse = await _context.Produs
                .Include(b => b.Status)
                .Include(b => b.CategoriiProdus)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Denumire)
                .ToListAsync();

            if(id!=null)
            {
                ProdusID = id.Value;
                Produs produs = ProdusD.Produse
                    .Where(i => i.ID == id.Value).Single();
                ProdusD.Categorii = produs.CategoriiProdus.Select(s => s.Categorie);
            }




           // Produs = await _context.Produs.Include(b=>b.Status).ToListAsync();
        }
    }
}
