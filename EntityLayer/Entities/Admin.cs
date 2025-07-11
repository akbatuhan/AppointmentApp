using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Entities
{
    public class Admin
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




    }
}
