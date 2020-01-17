using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class Decoration
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImgFile { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public virtual AdminApplication AdminApplication { get; set; }
    }
}
