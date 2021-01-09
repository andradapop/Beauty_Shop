using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beauty_Shop.Data;
using Beauty_Shop.Models;

namespace Beauty_Shop.Pages.Statusuri
{
    public class CreateModel : PageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public CreateModel(Beauty_Shop.Data.Beauty_ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Status Status { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Status.Add(Status);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
