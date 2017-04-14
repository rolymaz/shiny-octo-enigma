using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Services;

namespace TST.Services.OrderService
{
    public class StartOrderServiceResult
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