using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class EmailSendDto
    {
        [DisplayName("Adınız")]
        [Required(ErrorMessage = "{0} daxil etməyiniz vacibdir.")]
        [MaxLength(60, ErrorMessage = "{0} ən çox {1} simvoldan ibarət olmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} ən az {1} simvoldan ibarət olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("E-mail Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} daxil etməyiniz vacibdir.")]
        [MaxLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət olmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} ən az {1} simvoldan ibarət olmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Mövzu")]
        [Required(ErrorMessage = "{0} daxil etməyiniz vacibdir.")]
        [MaxLength(125, ErrorMessage = "{0} ən çox {1} simvoldan ibarət olmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} ən az {1} simvoldan ibarət olmalıdır.")]
        public string Subject { get; set; }
        [DisplayName("Mesaj")]
        [Required(ErrorMessage = "{0} daxil etməyiniz vacibdir.")]
        [MaxLength(1500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət olmalıdır.")]
        [MinLength(20, ErrorMessage = "{0} ən az {1} simvoldan ibarət olmalıdır.")]
        public string Message { get; set; }
    }
}
