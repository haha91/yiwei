//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace borading2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSold
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<System.DateTime> DateSold { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Products Products { get; set; }
        public virtual Stores Stores { get; set; }
    }
}
