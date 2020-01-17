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
    public class DeleteHallModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteHallModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public HallInformation HallInformation { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {
                return NotFound("Not Found");
            }

            else
            {
                HallInformation = await _db.HallInformation.FirstOrDefaultAsync(m => m.Id == Id);
            }
            if (HallInformation == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            _db.HallInformation.Remove(HallInformation);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}