using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class DanceTeam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public virtual AdminApplication AdminApplication { get; set; }
    }
}
