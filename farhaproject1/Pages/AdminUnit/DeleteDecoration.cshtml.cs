using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.AdminUnit
{
    public class DeleteDecorationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteDecorationModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Decoration Decoration { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
            Decoration = await _db.Decoration.FirstOrDefaultAsync(m => m.Id == Id);
            if (Decoration == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            _db.Decoration.Remove(Decoration);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}