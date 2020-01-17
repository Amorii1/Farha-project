using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class PhotoOfHall
    {
        public int Id { get; set; }
        public string ImgFile { get; set; }
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public virtual HallInformation HallInformation { get; set; }
    }
}
