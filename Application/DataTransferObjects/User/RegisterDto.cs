using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EntityMapping.User
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is required")]
        [MinLength(3)]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,20}$",
                    ErrorMessage = "Password is not valid, it must be between 8 - 20 characters and contain a number and a capital letter")]
        public string Password { get; set; }

    }
}
