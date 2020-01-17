using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
    public class AddNewHallModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _host;
        
      
        public AddNewHallModel(ApplicationDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        [BindProperty]
        public IFormFile img { get; set; }
        [BindProperty]
        public HallInformation HallInformation { get; set; }
        [BindProperty]
        public string userid { get; set; }
    
        public IList<ReservedDate> ReservedDate { get; set; }

      
        [BindProperty]
        public DateTime AddDatesList { get; set; }

        public IList<AddDateList> AddDateList { get; set; }
        [BindProperty]
        public IFormFile imgf { get; set; }

        public IList<AddPhoto> AddPhoto { get; set; }

        public IActionResult OnGet(string AdminId = null)
        {
            if (AdminId == null)
            {
                var ClaimId = (ClaimsIdentity)User.Identity;//يجيب كل id
                var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);//idيجيب الي سوه لوك ان
                AdminId = Claim.Value;

            };

            userid = AdminId;
            return Page();

        }
        public async Task<IActionResult> OnPostAddNewDate()
        {
          AddDateList v = new AddDateList
            {
                AddDates = AddDatesList
            };
            _db.AddDateList.Add(v);
            await _db.SaveChangesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAddNewPhoto()
        {
            string newfileName = string.Empty;
            if (imgf != null && imgf.Length > 0)
            {

                string fn = imgf.FileName;
                if (IsImagValidate(fn))
                {
                    string extension = Path.GetExtension(fn);
                    newfileName = Guid.NewGuid().ToString() + extension;
                    string filename = Path.Combine(_host.WebRootPath + "/Img/", newfileName);
                    await imgf.CopyToAsync(new FileStream(filename, FileMode.Create));
                }
                else
                {
                    return Page();
                }
            }
            AddPhoto v = new  AddPhoto
            {
               ImgFile= newfileName
            };
            _db.AddPhoto.Add(v);
            await _db.SaveChangesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostCreate()
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
            //var photo = new PhotoOfHall
            //{
            //    HallId = Information.Id,
            //    ImgFile = newfileName
            //};
          
            //_db.PhotoOfHall.Add(photo);
            //await _db.SaveChangesAsync();
            var Information = new HallInformation
            {
                AdminId = userid,
                HallName = HallInformation.HallName,
                Description = HallInformation.Description,
                Size = HallInformation.Size,
                Price = HallInformation.Price,
                ImgFile= newfileName


            };
            _db.HallInformation.Add(Information);
            await _db.SaveChangesAsync();

            AddDateList = await _db.AddDateList.ToListAsync();

            foreach (var item in AddDateList)
            {
                var AddDate = new ReservedDate
                {
                    NewDate = item.AddDates,
                    HallId = Information.Id
                };
                _db.ReservedDate.Add(AddDate);

            }
            _db.AddDateList.RemoveRange(AddDateList);
            await _db.SaveChangesAsync();

            AddPhoto = await _db.AddPhoto.ToListAsync();

            foreach (var item in AddPhoto)
            {
                var AddDate = new PhotoOfHall
                {
                   ImgFile = item.ImgFile,
                    HallId = Information.Id
                };
                _db.PhotoOfHall.Add(AddDate);

            }
            _db.AddPhoto.RemoveRange(AddPhoto);
            await _db.SaveChangesAsync();

            return RedirectToPage("index");

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
    