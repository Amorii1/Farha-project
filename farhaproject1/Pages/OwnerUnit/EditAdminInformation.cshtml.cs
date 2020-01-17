using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using farhaproject1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.OwnerUnit
{
   
    public class EditAdminInformationModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public EditAdminInformationModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AdminApplication InformationOfAdmin { get; set; }
        public async Task<IActionResult> OnGet(string Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
            InformationOfAdmin = await _db.AdminApplication.FirstOrDefaultAsync(m => m.Id == Id);
            if (InformationOfAdmin == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var InformationOfAdminFromDb = await _db.AdminApplication.FirstOrDefaultAsync(m => m.Id == InformationOfAdmin.Id);

            if (InformationOfAdminFromDb == null)
            {
                return NotFound();
            }
            InformationOfAdminFromDb.PhoneNumber = InformationOfAdmin.PhoneNumber;
            InformationOfAdminFromDb.Email = InformationOfAdmin.Email;
            InformationOfAdminFromDb.CenterName = InformationOfAdmin.CenterName;
            InformationOfAdminFromDb.CenterLocation = InformationOfAdmin.CenterLocation;
            await _db.SaveChangesAsync();

            return RedirectToPage("AdminInformation");

        }
    }
}