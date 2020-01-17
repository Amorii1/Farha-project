using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class CutomerSelect
    {
        public int Id { get; set; }
        [Required]
        public int DanceTeamId { get; set; }
        [ForeignKey("DanceTeamId")]
       virtual public DanceTeam DanceTeam { get; set; }
        [Required]
        public int DecorationId { get; set; }
        [ForeignKey("DecorationId")]
        virtual public Decoration Decoration { get; set; }
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        virtual public HallInformation HallInformation { get; set; }
    }
}
