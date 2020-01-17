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
    public class DeleteBookingModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteBookingModel(ApplicationDbContext db)
        {
            _db = db;
        }
      
        [BindProperty]
        public CustomerBooking customer { get; set; }
    
        public ReservedDate ReservedDate { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {

            customer = await _db.CustomerBooking.FirstOrDefaultAsync(customer => customer.Id == Id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            ReservedDate reserveddate = _db.ReservedDate.FirstOrDefault(c => c.HallId == customer.HallId && c.NewDate == customer.CustomerDate);
            _db.ReservedDate.Remove(reserveddate);
            _db.CustomerBooking.Remove(customer);
           
        await _db.SaveChangesAsync();
            return RedirectToPage("Booking", new { AdminId = customer.AdminId });
        }
    }
}