//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp295
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public string OrderNumber { get; set; }
        public string StoreCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string Terms { get; set; }
        public int TitleID { get; set; }
    
        public virtual Store Store { get; set; }
    }
}
