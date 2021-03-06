﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace borading2.Models
{
    public class ProductVIewModel
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(10, 100)]
        public int? Price { get; set; }
    }
}