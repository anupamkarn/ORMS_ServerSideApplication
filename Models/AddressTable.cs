//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORMS_WebService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AddressTable
    {
        public int AddressID { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string CustomerID { get; set; }
    
        public virtual CustomerTable CustomerTable { get; set; }
    }
}
