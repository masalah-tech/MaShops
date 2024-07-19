﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class ProductCart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
