using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class CustomerBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
      public int PhoneNumber { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CustomerDate { get; set; }
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public virtual HallInformation HallInformation { get; set; }
        public int DecorationId { get; set; }
        [ForeignKey("DecorationId")]
        public virtual Decoration Decoration { get; set; }
        public int DanceTeamId { get; set; }
        [ForeignKey("DanceTeamId")]
        public virtual DanceTeam DanceTeam { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public  virtual AdminApplication AdminApplication { get; set; }


    }
}
