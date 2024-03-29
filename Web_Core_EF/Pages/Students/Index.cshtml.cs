﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Web_Core_EF.Data.SchoolContext _context;

        public IndexModel(Web_Core_EF.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}
