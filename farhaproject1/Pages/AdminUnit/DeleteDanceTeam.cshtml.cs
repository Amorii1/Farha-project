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
    public class DeleteDanceTeamModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteDanceTeamModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public DanceTeam DanceTeam { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
            DanceTeam = await _db.DanceTeam.FirstOrDefaultAsync(m => m.Id == Id);
            if (DanceTeam == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            _db.DanceTeam.Remove(DanceTeam);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}