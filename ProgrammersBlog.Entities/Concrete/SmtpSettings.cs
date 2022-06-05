using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class SmtpSettings
    {
        [DisplayName("Server")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Server { get; set; }
        [DisplayName("Port")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(0,9999,ErrorMessage = "{0} cannot be less than {1} characters and pass {2} characters.")]
        public int Port { get; set; }
        [DisplayName("Sender E-mail")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(2, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string SenderName { get; set; }
        [DisplayName("Sender Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.EmailAddress,ErrorMessage = "{0} should be e-mail type format.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string SenderEmail { get; set; }
        [DisplayName("Username/E-mail")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(1, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password, ErrorMessage = "{0} should be password type format.")]
        [MaxLength(50, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Password { get; set; }
    }
}
