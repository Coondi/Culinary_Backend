using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Culinary.Data.BindingModels
{
    public class RegisterBindingModel
    {
        //[Required]
        //[EmailAddress]
        //[StringLength(40, ErrorMessage = "Email powinien zawierać od 3 do 40 znaków", MinimumLength = 3)]
        //public string Email { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Nazwa użytkownika powinna zawierać od 3 do 16 znaków", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
