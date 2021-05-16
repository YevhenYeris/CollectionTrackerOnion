using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class Collection : BaseEntity
    {
        [Required(ErrorMessage = Constants.Messages.Required)]
        public int CollectibleItemId { get; set; }

        public int CollectionFolderId { get; set; }

        [Display(Name = Constants.Names.CollectibleItem)]
        public CollectibleItem CollectibleItem { get; set; }

        [Display(Name = Constants.Names.Collection)]
        public CollectionFolder CollectionFolder { get; set; }

        [Display(Name = Constants.Names.Name)]
        public string Description { get; set; }
    }
}
