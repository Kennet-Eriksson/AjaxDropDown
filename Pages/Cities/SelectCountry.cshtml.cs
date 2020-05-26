using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgetTest04.Data;
using EgetTest04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EgetTest04.Pages.Cities
{
    public class SelectCountryModel : PageModel
    {
        private readonly EgetTest04Context _context;
        public SelectCountryModel(EgetTest04Context context)
        {
            _context = context;
        }

        public List<Country> Countries = new List<Country>();
        public async Task OnGetAsync()
        {
            Countries = await _context.Country.ToListAsync().ConfigureAwait(true);
        }

        [BindProperty]
        public int CId { get; set; }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("AddCity", new { CId });
        }
    }
}