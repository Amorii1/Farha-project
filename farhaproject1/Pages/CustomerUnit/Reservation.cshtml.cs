using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.CustomerUnit
{
    public class ReservationModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public ReservationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public double TotalPrices { get; set; }
        public DanceTeam DanceTeam { get; set; }
        [BindProperty]
        public HallInformation HallInformation { get; set; }
        public Decoration Decoration { get; set; }
        [BindProperty]
        public CutomerSelect CustomerSelect { get; set; }
        [BindProperty,Required]
        public TReservation TReservation { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
          
            CustomerSelect = await _db.CutomerSelect.Include(c=>c.HallInformation).Include(c=>c.Decoration).Include(c=>c.DanceTeam)
              . FirstOrDefaultAsync(c => c.Id == Id);
          
           
            TotalPrices = CustomerSelect.Decoration.Price + CustomerSelect.DanceTeam.Price + CustomerSelect.HallInformation.Price;
            return Page();

        }
        public async Task<IActionResult> OnPost()
        {

            TReservation.AdminId = CustomerSelect.HallInformation.AdminId;
            TReservation.TotalPrice = TotalPrices;
            TReservation.DecorationId = CustomerSelect.Decoration.Id;
            TReservation.DanceTeamId = CustomerSelect.DanceTeam.Id;
            TReservation.HallId = CustomerSelect.HallInformation.Id;

            
           _db.TReservation.Add(TReservation);
            await _db.SaveChangesAsync();
          

            return RedirectToPage("Index");
        }


    }
}