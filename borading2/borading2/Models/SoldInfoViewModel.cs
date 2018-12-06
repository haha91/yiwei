using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace borading2.Models
{
    public class SoldInfoViewModel
    {
        public List<CustomerViewModel> CustomerList { get; set; }
        public List<StoreViewModel> StoreList { get; set; }
        public List<ProductVIewModel> ProductList { get; set; }
    }
}