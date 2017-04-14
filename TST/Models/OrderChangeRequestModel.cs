using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Services;
using TST.Services.OrderService;

namespace TST.Models
{
    /// <summary>
    /// Model containing order data
    /// </summary>
    public class OrderChangeRequestModel
    {
        /// <summary>
        /// the order data
        /// </summary>
        public OrderChangeRequest ChangeRequest { get; set; }


        public TriggerEnum Trigger { get; set; }

        public WorkflowTypeEnum WorkFlowType { get; set; }

    }
}