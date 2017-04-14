using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Models;

namespace TST.Services.OrderService
{
    /// <summary>
    /// the result of the order state change
    /// </summary>
    public class OrderChangeResult
    {
        /// <summary>
        /// additional information r
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the result of the change
        /// </summary>
        public OrderChangeReponseEnum Result { get; set; }
    }
}