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
    public class AddCityModel : PageModel
    {
        private readonly EgetTest04Context _context;
        public AddCityModel(EgetTest04Context context)
        {
            _context = context;
        }

        public Country Country { get; set; }
        public int CnId { get; set; }
        public string CName { get; set; }
        public List<City> Cities { get; set; }

        public async Task OnGetAsync(int CId)
        {
            Cities = new List<City>();
            Country = await _context.Country.Where(c => c.Id == CId).FirstOrDefaultAsync().ConfigureAwait(true);
            CnId = CId;
            CName = Country.Name;
            Cities = await _context.City.Where(c => c.Country.Equals(Country.Name)).ToListAsync().ConfigureAwait(true);

        }

        // ---------------------------------------------------------------------------------------------------------------

        [BindProperty]
        public City InCity { get; set; }

        [BindProperty]
        public int CId { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            InCity.Country = await _context.Country.Where(c => c.Id == CId).Select(c => c.Name).FirstOrDefaultAsync().ConfigureAwait(true);
            _context.City.Add(InCity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddCity", new { CId });
        }

    }
}