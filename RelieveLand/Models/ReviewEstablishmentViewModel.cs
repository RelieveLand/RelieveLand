using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelieveLand.Models
{
    public class ReviewEstablishmentViewModel
    {
        public IEnumerable<ReviewModels> ReviewModel { get; set; }
        public EstablishmentModels EstablishmentModel { get; set; }
    }
}