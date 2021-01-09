using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beauty_Shop.Data;
using Beauty_Shop.Models;

namespace Beauty_Shop.Pages.Statusuri
{
    public class IndexModel : PageModel
    {
        private readonly Beauty_Shop.Data.Beauty_ShopContext _context;

        public IndexModel(Beauty_Shop.Data.Beauty_ShopContext context)
        {
            _context = context;
        }

        public IList<Status> Status { get;set; }

        public async Task OnGetAsync()
        {
            Status = await _context.Status.ToListAsync();
        }
    }
}
