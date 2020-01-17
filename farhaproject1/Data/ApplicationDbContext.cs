using System;
using System.Collections.Generic;
using System.Text;
using farhaproject1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdminApplication> AdminApplication { get; set; }
        public DbSet<HallInformation> HallInformation { get; set; }
        public DbSet<ReservedDate> ReservedDate { get; set; }
        public DbSet<Decoration> Decoration { get; set; }
        public DbSet<PhotoOfHall> PhotoOfHall { get; set; }
        public DbSet<PhotoOfDecoration> PhotoOfDecoration { get; set; }
        public DbSet<AddDateList> AddDateList { get; set; }
        public DbSet<CustomerBooking> CustomerBooking { get; set; }
        public DbSet<DanceTeam> DanceTeam{ get; set; }
        public DbSet<CutomerSelect> CutomerSelect{ get; set; }
        public DbSet<AddPhoto> AddPhoto { get; set; }
        public DbSet<TReservation> TReservation { get; set; }
    }
}
