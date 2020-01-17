using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.CustomerUnit
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
      
        [BindProperty]
        public IList<HallInformation> Hall { get; set; }
        [BindProperty]
        public IList<HallInformation> Halls { get; set; }
        [BindProperty]
        public string searchName { get; set; }
        [BindProperty]
        public string searchLocation { get; set; }
        [BindProperty]
        public double searchPrice { get; set; }
        [BindProperty]
        public IList<AdminApplication> Admin { get; set; }
        [BindProperty]
        public DateTime D1 { get; set; }
       
        public IList<ReservedDate> Reservation { get; set; }
        public async Task<IActionResult> OnGet(string searchPrice = null, string searchName = null, string searchLocation = null  ,DateTime? D1=null)
        {

            Hall = await _db.HallInformation.ToListAsync();
            Halls = await _db.HallInformation.ToListAsync();
            Admin = await _db.AdminApplication.ToListAsync();
            Reservation = await _db.ReservedDate.Where(c => c.Id == -1).ToListAsync();

           StringBuilder Param = new StringBuilder();
            Param.Append("&D1=");

            if (D1 != null)
            {
                Param.Append(D1);
            }

            Param.Append("&searchName=");

            if (searchName != null)
            {
                Param.Append(searchName);
            }

            Param.Append("&searchPrice=");

            if (searchPrice != null)
            {
                Param.Append(searchPrice);
            }

            Param.Append("&searchLocation=");

            if (searchLocation != null)
            {
                Param.Append(searchLocation);
            }

            if (searchName != null)
            {
                Hall = await _db.HallInformation.Where(u => u.HallName.ToLower().Contains(searchName.ToLower())).ToListAsync();

            }
            else
            {
                 if (searchLocation != null && searchPrice != null)
                {

                    Hall = await _db.HallInformation.Where(u => u.AdminApplication.CenterLocation.ToLower().Contains(searchLocation.ToLower()) && u.Price.ToString().Contains(searchPrice.ToLower())).ToListAsync();

                }
               else if (searchPrice != null)
                {
                    Hall = await _db.HallInformation.Where(u => u.Price.ToString().Contains(searchPrice.ToLower())).ToListAsync();

                }
                else
                {
                    if (searchLocation != null)
                    {
                        Hall = await _db.HallInformation.Where(u => u.AdminApplication.CenterLocation.ToLower().Contains(searchLocation.ToLower())).ToListAsync();

                    }
                    else
                    {
                        if (D1 != null)
                        {
                            List<int> listShoppingCard = _db.ReservedDate .Where(c => c.NewDate == D1)
               .Select(c => c.HallId)
               .ToList();
                           // Reservation = await _db.ReservedDate.Where(c => c.NewDate== D1).Include(c=>c.HallInformation).ToListAsync();
                            // Reservation=await _db.ReservedDate.Where(c => c.HallId == Reservation.H).Include(c => c.HallInformation).ToListAsync();
                            IQueryable<HallInformation> ListServiceTypes = from s in _db.HallInformation
                                                                           where !(listShoppingCard.Contains(s.Id))
                                                                       select s;
                            Hall = ListServiceTypes.ToList();

                        }
                    }
                }

            }



            return Page();
        }
    }
}