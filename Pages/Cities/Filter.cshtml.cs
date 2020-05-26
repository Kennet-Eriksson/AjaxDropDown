using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EgetTest04.Data;
using EgetTest04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EgetTest04.Pages.Cities
{
    public class FilterModel : PageModel
    {
        private readonly EgetTest04Context _context;
        public FilterModel(EgetTest04Context context)
        {
            _context = context;
        }
        public async Task<JsonResult> OnGetAsync(string id)
        {
            int x = 0;
            bool scss = Int32.TryParse(id, out x);
            if (scss)
            {
                List<Country> Countries = new List<Country>();
                Countries = await _context.Country.ToListAsync().ConfigureAwait(true);
                string cname = Countries[x - 1].Name;
                List<City> Cities = new List<City>();
                Cities = await _context.City.Where(c => c.Country == cname).ToListAsync().ConfigureAwait(true);
                return new JsonResult(Cities);
            }
            else
            {
                throw new System.InvalidOperationException("Not a number");
            }
        }
    }
}