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
    public class DetailsModel : PageModel
    {
        private readonly EgetTest04.Data.EgetTest04Context _context;

        public DetailsModel(EgetTest04.Data.EgetTest04Context context)
        {
            _context = context;
        }

        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await _context.Country.FirstOrDefaultAsync(m => m.Id == id);

            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
