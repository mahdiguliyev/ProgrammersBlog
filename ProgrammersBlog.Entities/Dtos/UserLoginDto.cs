using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("E-Mail Address")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} cannot be less than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
