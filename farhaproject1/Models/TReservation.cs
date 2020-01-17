using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class TReservation
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public virtual HallInformation HallInformation { get; set; }
        public int DecorationId { get; set; }
        [ForeignKey("DecorationId")]
        public virtual Decoration Decoration { get; set; }
    
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        virtual public AdminApplication AdminApplication{ get; set; }
       
        public int DanceTeamId { get; set; }
        [ForeignKey("DanceTeamId")]
        public virtual DanceTeam DanceTeam { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public DateTime D { get; set; }
        public double TotalPrice { get; set; }
    }
}
