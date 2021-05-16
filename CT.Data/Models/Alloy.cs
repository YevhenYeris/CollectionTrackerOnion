using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class Alloy : BaseNamedEntity
    {
        public virtual ICollection<Coin> Tokens { get; set; }
    }
}
