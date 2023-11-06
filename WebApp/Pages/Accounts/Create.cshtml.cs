using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Pages.Accounts
{
    public class CreateModel : PageModel 
    {
        public String ErrorMessage = "";

        private readonly WebApp.Models.ApplicationDbContext _context;

        public CreateModel(WebApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public String[] allCurrencyStrings { get; set; } = {
            "Jordanian Dinar (JOD)",
            "Egyptian Pound (EGP)",
            "Kuwaiti Dinar (KWD)",
            "United States Dollar (USD)"
        };

        public IActionResult OnGet()
        {
            userIds = _context.Users.Select(user => user.ID.ToString()).ToList();
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public List<string> userIds { get; set; } = new List<string>();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid || _context.Accounts == null || Account == null)
                {
                    return Page();
                }

                _context.Accounts.Add(Account);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.InnerException.Message;
                Console.WriteLine(ex);
                return Page();
            }
        }
    }
}
