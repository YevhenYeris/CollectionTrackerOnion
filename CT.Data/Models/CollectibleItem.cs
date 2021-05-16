using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CT.Data.Models
{
    public class CollectibleItem : BaseNamedEntity
    {
        [Display(Name = Constants.Names.Year)]
        public int Year { get; set; }

        [Display(Name = Constants.Names.Obverse)]
        public string Obverse { get; set; }

        [Display(Name = Constants.Names.Reverse)]
        public string Reverse { get; set; }

        [Display(Name = Constants.Names.Description)]
        public string Description { get; set; }

        [Display(Name = Constants.Names.Measurements)]
        public string Measuements { get; set; }

        [Required(ErrorMessage = Constants.Messages.Required)]
        public int CountryId { get; set; }

        [Required(ErrorMessage = Constants.Messages.Required)]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = Constants.Messages.Required)]
        public int CurrencyId { get; set; }

        [Display(Name = Constants.Names.Name)]
        public Currency Currency { get; set; }

        [Display(Name = Constants.Names.Country)]
        public Country Country { get; set; }

        [Display(Name = Constants.Names.Subject)]
        public Subject Subject { get; set; }

        public bool IsCommon { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}
