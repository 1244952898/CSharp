using EFCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreDemo.Data.SchoolContext _context;

        public DetailsModel(EFCoreDemo.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            var student = await _context.Students
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
