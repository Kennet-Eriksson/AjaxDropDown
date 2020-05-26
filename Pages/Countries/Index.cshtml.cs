using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgetTest04.Data;
using EgetTest04.Models;

namespace EgetTest04.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly EgetTest04.Data.EgetTest04Context _context;

        public IndexModel(EgetTest04.Data.EgetTest04Context context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; }

        public async Task OnGetAsync()
        {
            Country = await _context.Country.ToListAsync();
        }
    }
}
