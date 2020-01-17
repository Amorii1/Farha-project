using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.AdminUnit
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string userid { get; set; }
        [BindProperty]
        public IList<HallInformation> Hall { get; set; }
     
        public IList<Decoration> Decoration { get; set; }
        public IList<DanceTeam> DanceTeam { get; set; }
        public async Task<IActionResult> OnGet(string AdminId = null)
        {
            if (AdminId == null)
            {
                var ClaimId = (ClaimsIdentity)User.Identity;//يجيب كل id
                var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);//idيجيب الي سوه لوك ان
                AdminId = Claim.Value;

            };

            userid = AdminId;
            Hall = await _db.HallInformation.Where(c => c.AdminId == userid).ToListAsync();
           Decoration = await _db.Decoration.Where(c => c.AdminId == userid).ToListAsync();
            DanceTeam = await _db.DanceTeam.Where(c => c.AdminId == userid).ToListAsync();

            return Page();
        }
    }
}