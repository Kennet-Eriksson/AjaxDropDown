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
    public class ShowCitiesInCountryModel : PageModel
    {
        private readonly EgetTest04Context _context;
        public ShowCitiesInCountryModel(EgetTest04Context context)
        {
            _context = context;
        }
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<City> Cities { get; set; } = new List<City>();
        public async Task OnGetAsync()
        {
                Countries = await _context.Country.ToListAsync().ConfigureAwait(true);
                Countries.Insert(0, new Country { Id = 0, Name = "Select" });
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------------


        [BindProperty]
        public int InCountry { get; set; }

        [BindProperty]
        public int InCity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Cities = await _context.City.Where(c => c.Id == InCountry).ToListAsync().ConfigureAwait(true);
            Cities.Insert(0, new City { Id = 0, Country = "null", Name = "Select" });

            return Page();
        }
    }
}