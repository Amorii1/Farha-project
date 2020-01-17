using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace farhaproject1.Utility
{
    public class Request
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Request(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<TReservation>Reservation { get; set; }
        public int Re { get; set; }
        public async Task<int> ReservationRequest()
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            Re = 0;
            Reservation = await _db.TReservation.Where(c => c.AdminId == userId).ToListAsync();
            foreach (var item in Reservation)
            {
                Re = Re++;

            }
            return Re;
        }
    }
}
