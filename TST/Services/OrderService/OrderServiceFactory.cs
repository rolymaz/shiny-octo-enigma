using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Data;
using TST.Models;

namespace TST.Services.OrderService
{
    public class OrderServiceFactory
    {
        private Order _order;
        
        private SalesTrackerDbEntities db = new SalesTrackerDbEntities();

        /// <summary>
        /// Start the order service using an orderId. Use this when an order exists
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public IOrderService StartFactory(int orderId)
        {
            _order = db.Orders.Find(orderId);

            if (_order == null)
            {
                throw new Exception();

            }

            return GetService((WorkflowEnum)_order.WorkflowId);

        }

        /// <summary>
        /// Start the order service with the workflowid. Use this when the order is does not exist
        /// </summary>
        /// <param name="workFlowId"></param>
        /// <returns></returns>
        public IOrderService StartFactory(WorkflowEnum workFlowId)
        {
            return GetService(workFlowId);

        }


        private IOrderService GetService(WorkflowEnum workFlowId)
        {
            IOrderService orderService;

            switch (workFlowId)
            {

                case WorkflowEnum.Test:

                    //case 1: Test order service 
                    orderService = new TestOrderService();
                    break;


                case WorkflowEnum.ConsumerMobile:
                    //case 2: ConsumerMobile
                    orderService = new ConsumerMobileOrderService();
                    break;


                default:
                    throw new Exception();


            }

            return orderService;

        }
    }
}