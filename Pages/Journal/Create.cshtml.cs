using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApp.Data;
using JournalApp.Models;

namespace JournalApp.Pages_Journal
{
    public class CreateModel : PageModel
    {
        private readonly JournalApp.Data.AppDbContext _context;

        public CreateModel(JournalApp.Data.AppDbContext context)
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

            _context.JournalEntries.Add(JournalEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
