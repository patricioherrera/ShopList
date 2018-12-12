using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Son")]
    public class Son
    {
        public int SonId { get; set; }

        [Required]
        public int FatherId { get; set; }

        [Required]
        public String SonName { get; set; }
    }
}