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
    public class DeleteModel : PageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public DeleteModel(Beauty_Shop.Data.Beauty_ShopContext context)
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

            Produs = await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs.FindAsync(id);

            if (Produs != null)
            {
                _context.Produs.Remove(Produs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
