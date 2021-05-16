using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class Coin : CollectibleItem
    {
        [Required(ErrorMessage = Constants.Messages.Required)]
        public int ShapeId { get; set; }

        [Display(Name = Constants.Names.Shape)]
        public Shape Shape { get; set; }

        [Required(ErrorMessage = Constants.Messages.Required)]
        public int AlloyId { get; set; }

        [Display(Name = Constants.Names.Alloy)]
        public Alloy Alloy { get; set; }

        [Display(Name = Constants.Names.Weight)]
        public int Weight { get; set; }
    }
}
