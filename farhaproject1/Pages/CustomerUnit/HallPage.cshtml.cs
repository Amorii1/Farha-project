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
    public class HallPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public HallPageModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<DanceTeam> DanceTeam { get; set; }
        [BindProperty]
        public HallInformation HallInformation { get; set; }
        public IList<Decoration> Decoration { get; set; }
        [BindProperty]
        public CutomerSelect CutomerSelect { get; set; }
        public IList<PhotoOfHall> Photo { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            HallInformation = await _db.HallInformation.FirstOrDefaultAsync(c => c.Id == Id);
            Photo = await _db.PhotoOfHall.Where(c => c.HallId == Id).ToListAsync();
            DanceTeam = await _db.DanceTeam.Where(c => c.AdminId == HallInformation.AdminId).ToListAsync();
            Decoration = await _db.Decoration.Where(c => c.AdminId == HallInformation.AdminId).ToListAsync();

            return Page();

        }
        public async Task<IActionResult> OnPost()
        {
            var cselect = new CutomerSelect
            {
                DecorationId = CutomerSelect.DecorationId,
                DanceTeamId = CutomerSelect.DanceTeamId,
                HallId=HallInformation.Id,


            };
            _db.CutomerSelect.Add(cselect);
            await _db.SaveChangesAsync();
            return RedirectToPage("Reservation",new { Id=cselect.Id});
        }
    }
}