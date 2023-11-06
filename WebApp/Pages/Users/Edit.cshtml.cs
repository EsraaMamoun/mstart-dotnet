using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Models.ApplicationDbContext _context;

        public String ErrorMessage = "";

        public EditModel(WebApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user =  await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string action)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(User).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(User.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (action == "Save & Continue")
                {
                    return Page();
                }

                return RedirectToPage("./Index");

            } catch(Exception ex)
            {
                ErrorMessage = ex.InnerException.Message;
                Console.WriteLine(ex);
                return Page();
            }
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
