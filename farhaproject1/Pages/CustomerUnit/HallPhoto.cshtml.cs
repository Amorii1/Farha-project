using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.CustomerUnit
{
    public class HallPhotoModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public HallPhotoModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<PhotoOfDecoration> Photo { get; set; }
      
        public async Task<IActionResult> OnGet(int Id)
        {
        
        Photo = await _db.PhotoOfDecoration.Include(c=>c.Decoration).Where(c => c.DecorationId == Id).ToListAsync();
          

            return Page();

        }
    }
}