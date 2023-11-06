using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Models.ApplicationDbContext _context;

        public IndexModel(WebApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchUser { get; set; }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<User> query = _context.Users;

            if (!string.IsNullOrEmpty(SearchUser))
            {
                if (int.TryParse(SearchUser, out int searchNumber))
                {
                    query = query.Where(a => a.ID == searchNumber);
                }
                else
                {
                    query = query.Where(a => 
                    a.Username.Contains(SearchUser) || a.Email.Contains(SearchUser));
                }
            }

            User = await query.ToListAsync();
        }
    }
}
