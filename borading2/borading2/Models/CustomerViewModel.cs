using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace borading2.Models
{
    public class CustomerViewModel
    {
   
        public int Id { set; get; }
        [Required]
        [StringLength(50)]
        public string Name { set; get; }
        [Required]
        [StringLength(50)]
        public string Address { set; get; }

    }
}