using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace borading2.Models
{
    public class ProductSoldViewModel
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public List<ProductVIewModel> ProductList { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        public List<CustomerViewModel> CustomerList { get; set; }
        public int StoreId { get; set; }
        [Required]
        [StringLength(50)]
        public string StoreName { get; set; }
        public List<StoreViewModel> StoreList { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime soldDate { get; set; }
      
    }
}