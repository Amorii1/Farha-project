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
    public class BookingModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public BookingModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public string userid { get; set; }
        [BindProperty]
        public IList<CustomerBooking> customer { get; set; }
        public async Task<IActionResult> OnGet(string AdminId = null)
        {
            if (AdminId == null)
            {
                var ClaimId = (ClaimsIdentity)User.Identity;//يجيب كل id
                var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);//idيجيب الي سوه لوك ان
                AdminId = Claim.Value;

            };

            userid = AdminId;
           customer = await _db.CustomerBooking
                .Include(c=>c.HallInformation)
                .Include(c => c.Decoration)
                .Include(c=>c.DanceTeam)
               . Where(c => c.AdminId == userid).ToListAsync();
           

            return Page();
        }
       
    }
}