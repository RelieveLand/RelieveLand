using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RelieveLand.Models
{
    public class ReviewModels
    {
        [Key]
        public int ReviewID { get; set; }

        [DisplayName("Review Time Submitted")]
        public string ReviewTime { get; set; }
        [DisplayName("Overall Restroom Rating")]
        public int OverallRating { get; set; }
        [DisplayName("Odor Rating")]
        public int OdorRating { get; set; }
        [DisplayName("Appearance Rating")]
        public int AppearRating { get; set; }
        [DisplayName("Additional comments")]
        public string UserComments { get; set; }

        [ForeignKey("EstablishmentModels")]
        public int EstID { get; set; }
        public virtual EstablishmentModels Establishments { get; set; }
    }
}