using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Mail { get; set; }

        [Required]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [MaxLength(10, ErrorMessage = "Doğru Telefon numarası giriniz")]
        [MinLength(10, ErrorMessage = "Doğru Telefon numarası giriniz")]
        public string Number { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max 15 karakter girebilirsiniz")]
        [MinLength(6, ErrorMessage = "Min 6 karakter girebilirsiniz")]
        public string Password { get; set; }


        [Required]
        [MaxLength(15, ErrorMessage = "Max 15 karakter girebilirsiniz")]
        [MinLength(6, ErrorMessage = "Min 6 karakter girebilirsiniz")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Yanlış TC Numarası")]
        [MinLength(11, ErrorMessage = "Yanlış TC Numarası")]
        public string TC { get; set; }

        public List<Appointment> ?Appointments { get; set;}

    }
}
