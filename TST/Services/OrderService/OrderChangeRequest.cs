using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TST.Services.OrderService

{

    /// <summary>
    /// Contains data required to change the queue of a sale
    /// </summary>
    public class OrderChangeRequest
    {
        /// <summary>
        /// the id of the order
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// the user requesting the change
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// the reason for the change
        /// </summary>
        public int ReasonId { get; set; }

        /// <summary>
        /// additional notes explaining the change
        ///         /// </summary>
        public string NewNote { get; set; }

       
    }
}