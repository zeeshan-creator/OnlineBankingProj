//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBanking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            this.complains = new HashSet<complain>();
            this.fundtransfers = new HashSet<fundtransfer>();
        }
    
        public int Customer_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public long CNIC { get; set; }
        public string DateOfBirth { get; set; }
        public string Account_No { get; set; }
        public int AccountTypeId { get; set; }
        public string Email { get; set; }
        public string  Password{ get; set; }
    
        public virtual AccountType AccountType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<complain> complains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fundtransfer> fundtransfers { get; set; }
    }
}
