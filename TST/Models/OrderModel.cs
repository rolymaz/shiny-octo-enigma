using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.SQL;

namespace TST.Models
{
    /// <summary>
    /// Model containing order data
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// the order data
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// the logs associated with the order
        /// </summary>
        public IEnumerable<OrderLog> OrderLogs { get; set; }

    }
}