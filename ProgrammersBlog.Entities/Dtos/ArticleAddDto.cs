using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Title { get; set; }
        [DisplayName("Content")]
        [Required(ErrorMessage = "{0} is required.")]
        [MinLength(20, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Content { get; set; }
        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(250, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Thumbnail { get; set; }
        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayName("Seo Author")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string SeoAuthor { get; set; }
        [DisplayName("Seo Description")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(150, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Tags")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(70, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string SeoTags { get; set; }
        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool IsActive { get; set; }
    }
}
