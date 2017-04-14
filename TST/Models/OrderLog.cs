//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderLog
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public string Result { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public string ChangeBy { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public Nullable<int> ReasonId { get; set; }
        public Nullable<decimal> MinutesInQueue { get; set; }
    }
}
