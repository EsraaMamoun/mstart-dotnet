using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Models.ApplicationDbContext _context;

        public IndexModel(WebApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchAccount { get; set; }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {

            IQueryable<Account> query = _context.Accounts;
            if (!string.IsNullOrEmpty(SearchAccount))
            {
                if (int.TryParse(SearchAccount, out int searchNumber))
                {
                    query = query.Where(a =>
                        a.User_ID == searchNumber ||
                        a.ID == searchNumber ||
                        a.Account_Number == searchNumber.ToString());
                }
                else
                {
                    query = query.Where(a => a.Account_Number.Contains(SearchAccount));
                }
            }

            Account = await query.ToListAsync();

      
        }
    }
}
