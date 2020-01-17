using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class HallInformation
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public string Description { get; set; }
        public string ImgFile { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        //public DateTime DateExist { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public virtual AdminApplication AdminApplication { get; set; }
    }
}
