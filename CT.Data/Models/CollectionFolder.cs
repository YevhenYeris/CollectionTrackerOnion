using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class CollectionFolder : BaseEntity
    {
        [Required(ErrorMessage = Constants.Messages.Required)]
        public string UserId { get; set; }

        [Display(Name = Constants.Names.User)]
        public User User { get; set; }

        [Display(Name = Constants.Names.Name)]
        public string Description { get; set; }

        public ICollection<Collection> Collections { get; set; }
    }
}
