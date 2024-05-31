using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCoreDemo.Data;
using EFCoreDemo.Models;
using EFCoreDemo.Classes;

namespace EFCoreDemo.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly EFCoreDemo.Data.SchoolContext _context;
        private readonly IA _a0;
        private readonly IA _a1;

        public CreateModel(SchoolContext context, Func<Type, IA> func)
        {
            _context = context;
            _a0 = func(typeof(A0));
            _a1 = func(typeof(A1));
        }

        public IActionResult OnGet()
        {
            _a0.Test();
            _a1.Test();
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
