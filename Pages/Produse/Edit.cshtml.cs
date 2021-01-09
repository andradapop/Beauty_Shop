using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beauty_Shop.Data;
using Beauty_Shop.Models;

namespace Beauty_Shop.Pages.Produse
{
    public class EditModel : CategoriiProdusPageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public EditModel(Beauty_Shop.Data.Beauty_ShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(b=>b.Status)
                .Include(b=>b.CategoriiProdus)
                .ThenInclude(b=>b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Produs);

            ViewData["StatusID"] = new SelectList(_context.Status, "ID", "StatusVal");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null) { return NotFound(); }
            var produsToUpdate = await _context.Produs.Include(i => i.Status).Include(i => i.CategoriiProdus).ThenInclude(i => i.Categorie).FirstOrDefaultAsync(s => s.ID == id);

            if (produsToUpdate == null) { return NotFound(); }

            if (produsToUpdate == null) { return NotFound(); }
            if (await TryUpdateModelAsync<Produs>(
                produsToUpdate, 
                "Produs", 
                i => i.Denumire, i => i.Brand, 
                i => i.Pret, i => i.DataFabricarii, i => i.Status)) 

            {  
                UpdateProdusCategories(_context, selectedCategories, produsToUpdate); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index"); 
            }

            UpdateProdusCategories(_context, selectedCategories, produsToUpdate); 
            PopulateAssignedCategoryData(_context, produsToUpdate); 
            return Page();


           // return RedirectToPage("./Index");
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
