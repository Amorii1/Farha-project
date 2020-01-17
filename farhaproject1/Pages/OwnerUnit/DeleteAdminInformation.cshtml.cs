using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.OwnerUnit
{
    public class DeleteAdminInformationModel : PageModel
    {
      
            private readonly ApplicationDbContext _db;

            public DeleteAdminInformationModel(ApplicationDbContext db)
            {
                _db = db;
            }
            [BindProperty]
            public AdminApplication InformationOfAdmin { get; set; }
            public async Task<IActionResult> OnGet(string Id)
            {
                if (Id == null)
                {
                    return NotFound("Not Found");
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

            var userId = await _db.Users.FirstOrDefaultAsync(m => m.Id == InformationOfAdmin.Id);
            _db.Users.Remove(userId);
            await _db.SaveChangesAsync();

            return RedirectToPage("AdminInformation");
        }
        }
}