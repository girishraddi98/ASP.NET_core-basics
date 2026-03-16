using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntityFW_Razor.Data;
using EntityFW_Razor.Models;
using Microsoft.Data.SqlClient;

namespace EntityFW_Razor.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly EntityFW_Razor.Data.AppDbContext _context;

        public CreateModel(EntityFW_Razor.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

            //using(SqlCommand sqlCommand = )

        }
    }
}
