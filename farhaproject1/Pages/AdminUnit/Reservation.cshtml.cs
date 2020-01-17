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
    public class ReservationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ReservationModel(ApplicationDbContext db)
        {
            _db=db;
        }
        [BindProperty]
        public IList<TReservation> TReservation { get; set; }
        [BindProperty]
        public int IdR { get; set; }
        public CustomerBooking CustomerBooking { get; set; }
        public async Task<IActionResult> OnGet(String Id)
        {
            if (Id == null)
            {
                var ClaimId = (ClaimsIdentity)User.Identity;//يجيب كل id
                var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);//idيجيب الي سوه لوك ان
               Id = Claim.Value;

            };
            TReservation = await _db.TReservation.Include(c=>c.HallInformation).Include(c=>c.DanceTeam).Include(c=>c.Decoration).Where(c => c.AdminId == Id).ToListAsync();
                return Page();
        }
        public async Task<IActionResult> OnPostDeny()
        {
            var a = await _db.TReservation.FirstOrDefaultAsync(c => c.Id == IdR);
            _db.TReservation.Remove(a);
            await _db.SaveChangesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAccept()
        {
            var a = await _db.TReservation.FirstOrDefaultAsync(c => c.Id == IdR);
            CustomerBooking b = new CustomerBooking
            {
                HallId = a.HallId,
                DecorationId=a.DecorationId,
                DanceTeamId=a.DanceTeamId,
                AdminId=a.AdminId,
                CustomerDate=a.D,
                Name=a.Name,
                PhoneNumber=a.PhoneNumber
                
            };
            _db.CustomerBooking.Add(b);
            _db.TReservation.Remove(a);
            var AddDates = new ReservedDate
            {
                NewDate =a.D,
                HallId = a.HallId
            };
            _db.ReservedDate.Add(AddDates);
            await _db.SaveChangesAsync();



            return Page();
        }
    }
}