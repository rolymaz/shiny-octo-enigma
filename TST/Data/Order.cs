//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TST.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CampaignId { get; set; }
        public int TeamId { get; set; }
        public int LeadId { get; set; }
        public int CustomerId { get; set; }
        public int OrderQueueId { get; set; }
        public System.DateTime OrderQueueChangeDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string Owner { get; set; }
        public int SeqNo { get; set; }
        public int WorkflowId { get; set; }
        public string ChangeBy { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public string OrderRef { get; set; }
        public string AccountNo { get; set; }
        public string AssignedTo { get; set; }
        public Nullable<int> OrderPriority { get; set; }
        public string Notes { get; set; }
        public string CancelBy { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public Nullable<int> CancelReasonId { get; set; }
        public string IMEI { get; set; }
        public string MSISDN { get; set; }
        public Nullable<System.DateTime> ActivationDate { get; set; }
        public Nullable<System.DateTime> ContractExpiryDate { get; set; }
    }
}
