//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductAttribute
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }
        public string Sized { get; set; }
    
        public virtual ProductAttribute ProductAttribute1 { get; set; }
        public virtual ProductAttribute ProductAttribute2 { get; set; }
    }
}