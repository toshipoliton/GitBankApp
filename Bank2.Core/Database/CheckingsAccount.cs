//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank2.Core.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class CheckingsAccount
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public System.Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Person Person { get; set; }
    }
}