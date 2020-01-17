using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace farhaproject1.Pages.AdminUnit
{
    public class AddNewDanceTeamModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public AddNewDanceTeamModel(ApplicationDbContext db)
        {
            _db = db;

        }
        [BindProperty]
        public DanceTeam DanceTeam { get; set; }

        [BindProperty]
        public HallInformation HallInformation { get; set; }


        [BindProperty]
        public string userid { get; set; }
        public IActionResult OnGet(string AdminId = null)
        {
            if (AdminId == null)
            {
                var ClaimId = (ClaimsIdentity)User.Identity;//يجيب كل id
                var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);//idيجيب الي سوه لوك ان
                AdminId = Claim.Value;

            };

            userid = AdminId;
            return Page();

        }
        public async Task<IActionResult> OnPost()
        {
            var Information = new DanceTeam
            {
                AdminId = userid,
                Name = DanceTeam.Name,
                Price = DanceTeam.Price,


            };
            _db.DanceTeam.Add(Information);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");

        }

    }
}