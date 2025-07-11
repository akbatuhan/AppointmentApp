using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Doctor>? Doctors { get; set;}
    }
}
