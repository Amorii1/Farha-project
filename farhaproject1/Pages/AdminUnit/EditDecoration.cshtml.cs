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
    public class EditDecorationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _host;


        public EditDecorationModel(ApplicationDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        [BindProperty]
        public IFormFile img { get; set; }
        [BindProperty]
        public Decoration Decoration { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
           Decoration = await _db.Decoration.FirstOrDefaultAsync(m => m.Id == Id);
            if (Decoration== null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
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
            var InformationOfDecorationFromDb = await _db.Decoration.FirstOrDefaultAsync(m => m.Id == Decoration.Id);

            if (InformationOfDecorationFromDb == null)
            {
                return NotFound();
            }
            InformationOfDecorationFromDb.AdminId = Decoration.AdminId;
            InformationOfDecorationFromDb.Name = Decoration.Name;
            InformationOfDecorationFromDb.Price = Decoration.Price;
            InformationOfDecorationFromDb.ImgFile = newfileName;
            InformationOfDecorationFromDb.Description = Decoration.Description;
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