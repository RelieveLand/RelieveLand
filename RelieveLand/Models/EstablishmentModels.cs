using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelieveLand.Models
{
    public class EstablishmentModels
    {
        [Key]
        public int EstID { get; set; }

        [DisplayName("Establishment Name")]
        public string EstName { get; set; }
        [DisplayName("Link to image of establishment or restroom")]
        public string EstImage { get; set; }
        [DisplayName("Establishment Address")]
        public string EstAddress { get; set; }
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }
        [DisplayName("Main Borough")]
        public string BoroughPrimary { get; set; }
        [DisplayName("Secondary Borough (if necessary)")]
        public string BoroughSecondary { get; set; }
        [DisplayName("Hours of Operation")]
        public string HoursOfOper { get; set; }
        [DisplayName("If Single stall only, check here")]
        public bool SingleStall { get; set; }
        [DisplayName("Hand Dryer Type")]
        public string HandDryer { get; set; }
        [DisplayName("Does it have a changing station?")]
        public bool ChangingStation { get; set; }
        [DisplayName("Must make a purchase to use restroom?")]
        public bool PurchaseNeeded { get; set; }
        [DisplayName("Does it have a handicap specific stall?")]
        public bool HandicapStall { get; set; }
        [DisplayName("Feminine hygiene products?")]
        public bool HygieneProducts { get; set; }
        [DisplayName("Family/Unisex Option?")]
        public bool FamilyRestroom { get; set; }
        [DisplayName("Any Extras?")]
        public string Extras { get; set; }

        [DisplayName("Overall Average")]
        public float OverallAvg { get; set; }
        [DisplayName("Odor Average")]
        public float OdorAvg { get; set; }
        [DisplayName("Appearance Average")]
        public float AppearAvg { get; set; }

        public virtual ICollection<EstablishmentModels> Establishments { get; set; }
    }
}