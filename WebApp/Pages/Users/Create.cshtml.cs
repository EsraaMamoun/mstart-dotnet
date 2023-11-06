using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        public String ErrorMessage = "";

        private readonly WebApp.Models.ApplicationDbContext _context;

        public CreateModel(WebApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
              if (!ModelState.IsValid || _context.Users == null || User == null)
                {
                    return Page();
                }

                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            } catch (Exception ex)
            {
                ErrorMessage = ex.InnerException.Message;
                Console.WriteLine(ex);
                return Page();
            }
        }
    }
}
