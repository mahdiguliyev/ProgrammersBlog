using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Concrete
{
    public class ValidationError
    {
        public string PropertyName { get; set; } //Ex: CategoryName
        public string Message { get; set; } //Ex: Category Name cannot pass 100 characters.
    }
}
