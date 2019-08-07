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
    
    public partial class CustomerTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerTable()
        {
            this.AddressTables = new HashSet<AddressTable>();
            this.CartTables = new HashSet<CartTable>();
            this.OrderTables = new HashSet<OrderTable>();
        }
    
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string Status { get; set; }
        public bool IsEmailIDVerified { get; set; }
        public bool IsMobileNoVerified { get; set; }
        public string EmailGenCode { get; set; }
        public string MobileGenCode { get; set; }
        public string CustomerName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressTable> AddressTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartTable> CartTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
