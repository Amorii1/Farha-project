using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class PhotoOfDecoration
    {
        public int Id { get; set; }
        public string ImgFile { get; set; }
        public int DecorationId { get; set; }
        [ForeignKey("DecorationId")]
        public virtual Decoration Decoration { get; set; }
    }
}
