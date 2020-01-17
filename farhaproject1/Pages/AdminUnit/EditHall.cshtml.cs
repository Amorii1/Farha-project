using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using farhaproject1.Data;
using farhaproject1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace farhaproject1.Pages.AdminUnit
{
    public class EditHallModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _host;


        public EditHallModel(ApplicationDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        [BindProperty]
        public IFormFile img { get; set; }

        [BindProperty]
        public HallInformation HallInformation { get; set; }
        [BindProperty]
        public IList<ReservedDate> ReservedDate { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
            HallInformation = await _db.HallInformation.FirstOrDefaultAsync(m => m.Id == Id);
            if (HallInformation == null)
            {
                return NotFound();
            }
            ReservedDate = await _db.ReservedDate.Where(c => c.HallId == Id).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteHall(int Id)
        {
            var DateOfHallFromDb = await _db.ReservedDate.FirstOrDefaultAsync(m => m.Id == Id);

            _db.ReservedDate.Remove(DateOfHallFromDb);

            await _db.SaveChangesAsync();

            return RedirectToPage("EditHall",new { Id = DateOfHallFromDb.HallId });

        }
      
        public async Task<IActionResult> OnPostUpdate()
        {
            string newfileName = string.Empty;
            if (img != null && img.Length > 0)
            {

                string fn = img.FileName;
                if (IsImagValidate(fn))
                {
                    string extension = Path.GetExtension(fn);
                    newfileName = Guid.NewGuid().ToString() + extension;
                    string filename = Path.Combine(_host.WebRootPath + "/Img/", newfileName);
                    await img.CopyToAsync(new FileStream(filename, FileMode.Create));
                }
                else
                {
                    return Page();
                }
            }
            var InformationOfHallFromDb = await _db.HallInformation.FirstOrDefaultAsync(m => m.Id == HallInformation.Id);

            if (InformationOfHallFromDb == null)
            {
                return NotFound();
            }
            InformationOfHallFromDb.AdminId = HallInformation.AdminId;
            InformationOfHallFromDb.HallName= HallInformation.HallName;
            InformationOfHallFromDb.Price = HallInformation.Price;
            InformationOfHallFromDb.Size = HallInformation.Size;
            InformationOfHallFromDb.Description = HallInformation.Description;
            InformationOfHallFromDb.ImgFile = newfileName;
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
        private bool IsImagValidate(string filename)
        {
            string extension = Path.GetExtension(filename);
            if (extension.Contains(".png"))
                return true;
            if (extension.Contains(".PNG"))
                return true;
            if (extension.Contains(".jpeg"))
                return true;
            if (extension.Contains(".jpg"))
                return true;
            if (extension.Contains(".gif"))
                return true;
            return false;
        }
    }
}