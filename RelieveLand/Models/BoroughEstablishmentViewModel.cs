using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelieveLand.Models
{
    public class BoroughEstablishmentViewModel
    {
        public BoroughModels BoroughModel { get; set; }
        public IQueryable<EstablishmentModels> EstablishmentModel { get; set; }
    }
}