using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Archiva.Data;
using Archiva.Models;

namespace Archiva.Pages_Journal
{
    public class IndexModel : PageModel
    {
        private readonly Archiva.Data.AppDbContext _context;

        public IndexModel(Archiva.Data.AppDbContext context)
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
