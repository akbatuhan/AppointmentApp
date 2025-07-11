using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("PatientId")]
        [Required]
        public int PatientId { get; set; }

        [Required]
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Hour { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }
}
