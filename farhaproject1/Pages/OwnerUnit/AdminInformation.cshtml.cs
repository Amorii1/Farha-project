using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using farhaproject1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.OwnerUnit
{
    public class AdminInformationModel : PageModel
    {
       // [Authorize(Roles = SD.AdminEndUser)]

        private readonly ApplicationDbContext _db;

        public AdminInformationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IList<AdminApplication> InformationOfAdmin { get; set; }
       
        public async Task<IActionResult> OnGet()
        {
            InformationOfAdmin = await _db.AdminApplication.ToListAsync();
            return Page(); 

            
        

        }
    }
}
