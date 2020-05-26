using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgetTest04.Data;
using EgetTest04.Models;

namespace EgetTest04.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly EgetTest04.Data.EgetTest04Context _context;

        public DetailsModel(EgetTest04.Data.EgetTest04Context context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FirstOrDefaultAsync(m => m.Id == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
