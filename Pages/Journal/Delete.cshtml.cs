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
    public class DeleteModel : PageModel
    {
        private readonly JournalApp.Data.AppDbContext _context;

        public DeleteModel(JournalApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JournalEntry JournalEntry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalentry = await _context.JournalEntries.FirstOrDefaultAsync(m => m.Id == id);

            if (journalentry is not null)
            {
                JournalEntry = journalentry;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalentry = await _context.JournalEntries.FindAsync(id);
            if (journalentry != null)
            {
                JournalEntry = journalentry;
                _context.JournalEntries.Remove(JournalEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
