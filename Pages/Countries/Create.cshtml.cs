using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgetTest04.Data;
using EgetTest04.Models;

namespace EgetTest04.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private readonly EgetTest04.Data.EgetTest04Context _context;

        public CreateModel(EgetTest04.Data.EgetTest04Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Country.Add(Country);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
