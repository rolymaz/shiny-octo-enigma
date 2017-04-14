using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TST.Models;

namespace TST.Services.OrderService
{
   public interface IOrderService
    {
        StartOrderServiceResult StartService(OrderChangeRequest orderChangeRequest);             

        OrderChangeResult Open();
        OrderChangeResult Close();
        OrderChangeResult Pass();
        OrderChangeResult Fail();
        OrderChangeResult Cancel();
        OrderChangeResult Override(OrderChangeRequest request, OrderQueueEnum ToQueue);

        Order GetOrder();
        Order CreateOrder(NewOrder newOrder);
        
    }
}
