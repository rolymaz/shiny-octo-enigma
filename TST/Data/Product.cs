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
    
    public partial class Product
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string tOffer { get; set; }
        public string tFeatureCode { get; set; }
        public string tFeatureDescr { get; set; }
        public string tPricePlan { get; set; }
        public Nullable<decimal> tRental { get; set; }
        public Nullable<decimal> tCommExVat { get; set; }
        public Nullable<decimal> tCommIncVat { get; set; }
        public Nullable<int> ProductStatusId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int ProductTemplateId { get; set; }
    }
}
