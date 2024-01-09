using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.ViewModels.AccountVM
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }
    }
}
