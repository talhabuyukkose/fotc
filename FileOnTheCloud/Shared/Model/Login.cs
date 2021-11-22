using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.Model
{
    public class Login
    {
        [Required(ErrorMessage = "Email adresini giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz")]
        public string password { get; set; }
    }
}
