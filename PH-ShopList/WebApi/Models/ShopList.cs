using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    [Table("ShopList")]
    public class ShopList
    {
        public int ShopListId { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public int Status { get; set; }

        public DateTime Initial { get; set; }
      
        public virtual List<Product> Products { get; set; }

    }
}