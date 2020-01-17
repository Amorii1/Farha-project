using farhaproject1.Data;
using farhaproject1.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Data
{
    public class DbInitializar:IDbInitializer
    {


        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializar(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async void Initializer()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }


            }
            catch (Exception ex)
            {

            }
            if (_roleManager.RoleExistsAsync(SD.OwnerEndUser).GetAwaiter().GetResult())
            {
                return;
            }
            _roleManager.CreateAsync(new IdentityRole(SD.OwnerEndUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PhoneNumber = "123456",
                EmailConfirmed = true,
            }, "Qwe123!@").GetAwaiter().GetResult();
            IdentityUser user = _db.Users.FirstOrDefaultAsync(u => u.Email == "admin@gmail.com").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, SD.OwnerEndUser).GetAwaiter().GetResult();

        }
    }
}
