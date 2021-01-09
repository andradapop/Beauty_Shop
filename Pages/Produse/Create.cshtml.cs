using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beauty_Shop.Data;
using Beauty_Shop.Models;

namespace Beauty_Shop.Pages.Produse
{
    public class CreateModel : CategoriiProdusPageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public CreateModel(Beauty_Shop.Data.Beauty_ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StatusID"] = new SelectList(_context.Set<Status>(), "ID", "StatusVal");
            var produs = new Produs();
            produs.CategoriiProdus = new List<CategorieProdus>();
            PopulateAssignedCategoryData(_context, produs);
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.CategoriiProdus = new List<CategorieProdus>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieProdus
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newProdus.CategoriiProdus.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Produs>(newProdus, "Produs", i=>i.Denumire, i=>i.Brand, i=>i.Pret, i=>i.DataFabricarii, i=>i.StatusID))
            {
                _context.Produs.Add(newProdus);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProdus);
            return Page();

        }
    }
}
