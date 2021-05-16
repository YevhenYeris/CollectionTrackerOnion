using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace CT.Data.Models
{
    public class BaseNamedEntity : BaseEntity
    {
        [Required(ErrorMessage = Constants.Messages.Required)]
        [Display(Name = Constants.Names.Name)]
        public string Name { get; set; }
    }
}
