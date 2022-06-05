using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.MVC.Areas.Admin.Models
{
    public class ArticleRightSideBarWidgetOptionsViewModel
    {
        [DisplayName("Widget Title")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(150, ErrorMessage = "{0} cannot pass {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} cannot be less than {1} characters.")]
        public string Header { get; set; }
        [DisplayName("Article Count")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Range(0, 50, ErrorMessage = "{0} cannot be less than {1} characters and pass {2} characters.")]
        public int TakeSize { get; set; }
        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} is required.")]
        public int CategoryId { get; set; }
        [DisplayName("Filter Type")]
        [Required(ErrorMessage = "{0} is required.")]
        public FilterBy FilterBy { get; set; }
        [DisplayName("Order Type")]
        [Required(ErrorMessage = "{0} is required.")]
        public OrderBy OrderBy { get; set; }
        [DisplayName("Order Type (Desc/Ascend)")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool IsAscending { get; set; }
        [DisplayName("Start Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date, ErrorMessage = "{0} should be date type format.")]
        public DateTime StartAt { get; set; }
        [DisplayName("End Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date, ErrorMessage = "{0} should be Date type format.")]
        public DateTime EndAt { get; set; }
        [DisplayName("Max View Count")]
        [Required(ErrorMessage = "{0} is required.")]
        public int MaxViewCount { get; set; }
        [DisplayName("Min View Count")]
        [Required(ErrorMessage = "{0} is required.")]
        public int MinViewCount { get; set; }
        [DisplayName("Max Comment Count")]
        [Required(ErrorMessage = "{0} is required.")]
        public int MaxCommentCount { get; set; }
        [DisplayName("Min Comment Count")]
        [Required(ErrorMessage = "{0} is required.")]
        public int MinCommentCount { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
