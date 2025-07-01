using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Archiva.Data;
using Archiva.Models;

namespace Archiva.Pages_Journal
{
    public class CreateModel : PageModel
    {
        private readonly Archiva.Data.AppDbContext _context;

        public CreateModel(Archiva.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JournalEntry JournalEntry { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Automatically set the DateCreated timestamp
            JournalEntry.DateCreated = DateTime.Now;

            _context.JournalEntries.Add(JournalEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
