using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{   [Table("Father")]
    public class Father
    {
        public int FatherId { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public String FatherName { get; set; }

    }
}