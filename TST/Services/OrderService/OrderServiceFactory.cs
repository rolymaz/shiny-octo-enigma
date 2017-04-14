using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TST.Models;

namespace TST.Services.OrderService
{
    public class OrderServiceFactory
    {
        public IOrderService StartFactory(WorkflowTypeEnum workflowId)
        {

            IOrderService orderService;

            switch (workflowId)
            {

                case WorkflowTypeEnum.Test:

                    //case 1: Test workflow
                    orderService = new ConsumerMobileOrderService();
                    break;


                case WorkflowTypeEnum.ConsumerMobile:
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