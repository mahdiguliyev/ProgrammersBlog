using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DisplayName("Confirm New Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password confirmation does not match.")]
        public string RepeatPassword { get; set; }
    }
}
