using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TST.Services.OrderService
{
    /// <summary>
    /// Contains data to create a new order.
    /// </summary>
    public class NewOrder
    {
        /// <summary>
        /// the user who created the order
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// the id of the team of the user who created the order
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// the id of the customer
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// the date the order was created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// the id of the campaign the order was created on
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// the id of the lead
        /// </summary>
        public int LeadId { get; set; }

        /// <summary>
        /// the owner of the order. Typically this is the creator of the sale, however, it can be changed. Determines who earns the commission on the sale
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The user who is assigned to work the order. Changes as it moves through the order process. 
        /// </summary>
        public string AssignedTo { get; set; }
    }
}