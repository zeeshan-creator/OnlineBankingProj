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
    
    public partial class complain
    {
        public int Complain_Id { get; set; }
        public string ComplainTo { get; set; }
        public string ComplainFrom { get; set; }
        public string Complain_Subject { get; set; }
        public string DescriptionMsg { get; set; }
        public string Date { get; set; }
        public Nullable<int> Customer_id { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
