using EFCoreDemo.Classes;
using EFCoreDemo.Data;
using EFCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

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
            var emptyStudent = new Student();
            if (await TryUpdateModelAsync(emptyStudent, "student", s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Students.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }


    }
}
