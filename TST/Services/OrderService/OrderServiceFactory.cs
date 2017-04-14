using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Models;

namespace TST.Services.OrderService
{
    public class OrderServiceFactory
    {
        public IOrderService StartFactory(WorkflowEnum workflowId)
        {

            IOrderService orderService;

            switch (workflowId)
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