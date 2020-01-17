using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class ReservedDate
    {
        public int Id { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime NewDate { get; set; }

        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public virtual HallInformation HallInformation { get; set; }
    }
}
