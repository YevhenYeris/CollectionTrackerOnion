using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class Subject : BaseNamedEntity
    {
        public virtual ICollection<CollectibleItem> CollectibleItems { get; set; }
    }
}
