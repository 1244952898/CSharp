using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Core_EF.Data;
using Web_Core_EF.Models;

namespace Web_Core_EF.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Web_Core_EF.Data.SchoolContext _context;

        public DetailsModel(Web_Core_EF.Data.SchoolContext context)
        {
            _context = context;
        }

      public Student Student=default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var s =await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            //Student = await _context.Students?.FirstOrDefaultAsync(m => m.ID == id.Value);
            //Student = await _context.Students.SingleAsync(m => m.ID == id);
            Student = await _context.Students
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
