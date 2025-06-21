using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApp.Data;
using JournalApp.Models;

namespace JournalApp.Pages_Journal
{
    public class IndexModel : PageModel
    {
        private readonly JournalApp.Data.AppDbContext _context;

        public IndexModel(JournalApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JournalEntry = await _context.JournalEntries.ToListAsync();
        }
    }
}
