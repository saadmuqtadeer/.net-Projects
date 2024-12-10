﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DockerAPI.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
