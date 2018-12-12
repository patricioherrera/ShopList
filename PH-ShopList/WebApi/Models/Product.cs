using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(18)]
        [DisplayName("Codigo del producto")]
        public String CodeProduct { get; set; }

        [Required]
        [DisplayName("Descripción")]
        public String Description { get; set; }

        [Required]
        public String UM { get; set; }

        [Required]
        [DisplayName("Precio")]
        public Decimal Price { get; set; }
    }
}