using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CT.Data.Models
{
    public class User : IdentityUser
    {
        public string Description { get; set; }

        [Required(ErrorMessage = Constants.Messages.Required)]
        public int CountryId { get; set; }

        [Display(Name = Constants.Names.Name)]
        public Country Country { get; set; }

        public ICollection<CollectionFolder> CollectionFolders { get; set; }
    }
}
