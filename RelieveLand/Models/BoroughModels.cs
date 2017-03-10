using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelieveLand.Models
{
    public class BoroughModels
    {
        [Key]
        public int BoroughID { get; set; }

        public string BoroughName { get; set; }
    }
}