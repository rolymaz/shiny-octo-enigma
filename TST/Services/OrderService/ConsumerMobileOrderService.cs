using CsvHelper;
using Stateless;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using TST.Models;




namespace TST.Services.OrderService
{
    public class ConsumerMobileOrderService : IOrderService
    {
        private StateMachine<OrderQueueEnum, TriggerEnum> _stateMachine;
        private Order _order;
        private OrderChangeRequest _orderChange;
        private SalesTrackerDbEntities db = new SalesTrackerDbEntities();

        //define the triggers which will have parameters.
        //private StateMachine<OrderQueueEnum, TriggerEnum>.TriggerWithParameters<OrderChangeRequest> _onCancelTrigger;
        //private StateMachine<OrderQueueEnum, TriggerEnum>.TriggerWithParameters<OrderChangeRequest> _onFailTrigger;
        //private StateMachine<OrderQueueEnum, TriggerEnum>.TriggerWithParameters<OrderChangeRequest> _onPassCaptureTrigger;
        //private StateMachine<OrderQueueEnum, TriggerEnum>.TriggerWithParameters<OrderChangeRequest> _onPassTrigger;

      


        public StartOrderServiceResult StartService(OrderChangeRequest orderChange)
        {
            StartOrderServiceResult result = new StartOrderServiceResult();

            _orderChange = orderChange;

            _order = db.Orders.Find(orderChange.OrderId);

            //TODO: check that _order is valid, else return error

            OrderQueueEnum currenStatus = (OrderQueueEnum)_order.OrderQueueId;

            _stateMachine = Initialise(currenStatus);

            return result;


        }


        /// <summary>
        /// setups stateless and defines the path an order can take.
        /// </summary>
        /// <param name="initialOrderQueue"></param>
        /// <returns></returns>
        private StateMachine<OrderQueueEnum, TriggerEnum> Initialise(OrderQueueEnum initialOrderQueue)
        {

            if (initialOrderQueue == OrderQueueEnum.None)
            {
                throw new Exception("Invalid OrderQueueEnum. Cannot start StateEngine with OrderQueueEnum = None");
            }


            _stateMachine = new StateMachine<OrderQueueEnum, TriggerEnum>(initialOrderQueue);

            //sample code if we need parameterised triggers:
            //_onCancelTrigger = _stateMachine.SetTriggerParameters<OrderChangeRequest>(TriggerEnum.Cancel);
            //_onFailTrigger = _stateMachine.SetTriggerParameters<OrderChangeRequest>(TriggerEnum.Fail);
            //_onPassCaptureTrigger = _stateMachine.SetTriggerParameters<OrderChangeRequest>(TriggerEnum.PassToCapture);


            _stateMachine.OnTransitioned(OnTransition);


            //Opened = 1,
            _stateMachine.Configure(OrderQueueEnum.Opened)
            .Permit(TriggerEnum.Open, OrderQueueEnum.NewOrder);
            //exmple of how to raise enter & exit events
            //.OnEntry(() => EnterOpened())
            //.OnExit(() => ExitOpened());

            //NewOrder = 2,
            _stateMachine.Configure(OrderQueueEnum.NewOrder)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingCompliance)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);
            //.OnEntry(() => EnterNewOrder());

            //PendingFix = 3,
            _stateMachine.Configure(OrderQueueEnum.PendingFix)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingCompliance)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);

            //PendingCompliance = 4,
            _stateMachine.Configure(OrderQueueEnum.PendingCompliance)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingPostVet)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel)
            .Permit(TriggerEnum.Fail, OrderQueueEnum.PendingFix);
            //.OnEntryFrom<OrderChangeRequest>(_onFailTrigger, (OrderChangeRequest) => EnterPendingFix(OrderChangeRequest));

            //PendingComplianceFix = 5,
            _stateMachine.Configure(OrderQueueEnum.PendingComplianceFix)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingCompliance)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);


            //PendingPostVet = 6,
            _stateMachine.Configure(OrderQueueEnum.PendingPostVet)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingCapture)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel)
            .Permit(TriggerEnum.Fail, OrderQueueEnum.PendingPostVetFix);
            // .OnEntryFrom<OrderChangeRequest>(_onFailTrigger, (OrderChangeRequest) => EnterPendingPostVetFix(OrderChangeRequest));

            //PendingPostVetFix = 7,
            _stateMachine.Configure(OrderQueueEnum.PendingPostVetFix)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingPostVet)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);


            //PendingCapture = 8,
            _stateMachine.Configure(OrderQueueEnum.PendingCapture)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingDelivery)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel)
            .Permit(TriggerEnum.Fail, OrderQueueEnum.PendingCaptureFix);
            //.OnEntryFrom<OrderChangeRequest>(_onFailTrigger, (OrderChangeRequest) => EnterPendingCaptureFix(OrderChangeRequest));


            //PendingCaptureFix = 9,
            _stateMachine.Configure(OrderQueueEnum.PendingCaptureFix)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingCapture)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);


            //PendingDelivery = 10,
            _stateMachine.Configure(OrderQueueEnum.PendingDelivery)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingActivation)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel)
            .Permit(TriggerEnum.Fail, OrderQueueEnum.PendingDeliveryFix);
            //.OnEntryFrom<OrderChangeRequest>(_onFailTrigger, (OrderChangeRequest) => EnterPendingDeliveryFix(OrderChangeRequest));

            //PendingDeliveryFix = 11,
            _stateMachine.Configure(OrderQueueEnum.PendingDeliveryFix)
            .Permit(TriggerEnum.Pass, OrderQueueEnum.PendingDelivery)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);

            //PendingActivation = 12,
            _stateMachine.Configure(OrderQueueEnum.PendingActivation)
            .Permit(TriggerEnum.Close, OrderQueueEnum.Closed)
            .Permit(TriggerEnum.Cancel, OrderQueueEnum.PendingCancel);

            //PendingCancel = 13,     
            _stateMachine.Configure(OrderQueueEnum.PendingCancel)
            .Permit(TriggerEnum.Close, OrderQueueEnum.Closed);
            //.OnEntryFrom<OrderChangeRequest>(_onCancelTrigger, (OrderChangeRequest) => EnterPendingCancel(OrderChangeRequest));

            //Closed = 14,
            _stateMachine.Configure(OrderQueueEnum.Closed);
            // .OnEntry(() => EnterClosed())
            //.OnExit(() => ExitClosed());
            
            return _stateMachine;


        }



      
        /// <summary>
        /// Attempts to fail an order 
        /// </summary>
        /// <returns></returns>
        public OrderChangeResult Fail()
        {
            OrderChangeResult result = new OrderChangeResult();

            if (_stateMachine.CanFire(TriggerEnum.Fail))
            {
                _stateMachine.Fire(TriggerEnum.Fail);
                result.Result = OrderChangeReponseEnum.Success;
                result.Description = "Fail was successful";
                return result;
            }
            else
            {
                result.Result = OrderChangeReponseEnum.Fail;
                result.Description = "Cancel was unsuccessful";
                return result;
            }
        }

        /// <summary>
        /// Attempts to open an order and initiate the workflow
        /// </summary>
        /// <returns></returns>
        public OrderChangeResult Open()
        {
            OrderChangeResult result = new OrderChangeResult();


            if (_stateMachine.CanFire(TriggerEnum.Open))
            {
                _stateMachine.Fire(TriggerEnum.Open);
                result.Result = OrderChangeReponseEnum.Success;
                result.Description = "Open was successful";
                return result;
            }
            else
            {
                result.Result = OrderChangeReponseEnum.Fail;
                result.Description = "Open was unsuccessful";
                return result;
            }
        }

        /// <summary>
        /// Attempts to cancel the order
        /// </summary>
        /// <returns></returns>
        public OrderChangeResult Cancel()
        {
            OrderChangeResult result = new OrderChangeResult();


            if (_stateMachine.CanFire(TriggerEnum.Cancel))
            {
                _stateMachine.Fire(TriggerEnum.Cancel);
                result.Result = OrderChangeReponseEnum.Success;
                result.Description = "Cancel was successful";
                return result;
            }
            else
            {
                result.Result = OrderChangeReponseEnum.Fail;
                result.Description = "Cancel was unsuccessful";
                return result;
            }
        }

        /// <summary>
        /// Passes the order to the next workflow step
        /// </summary>
        /// <returns></returns>
        public OrderChangeResult Pass()
        {
            OrderChangeResult result = new OrderChangeResult();

            if (_stateMachine.CanFire(TriggerEnum.Pass))
            {
                _stateMachine.Fire(TriggerEnum.Pass);

                result.Result = OrderChangeReponseEnum.Success;
                result.Description = "Pass was successful";
                return result;
            }
            else
            {
                result.Result = OrderChangeReponseEnum.Fail;
                result.Description = "Pass was unsuccessful";
                return result;
            }
        }


        /// <summary>
        /// Closes the order and ends the workflow
        /// </summary>
        /// <returns></returns>
        public OrderChangeResult Close()
        {
            OrderChangeResult result = new OrderChangeResult();

            if (_stateMachine.CanFire(TriggerEnum.Close))
            {
                _stateMachine.Fire(TriggerEnum.Close);

                result.Result = OrderChangeReponseEnum.Success;
                result.Description = "Close was successful";
                return result;
            }
            else
            {

                result.Result = OrderChangeReponseEnum.Fail;
                result.Description = "Close was unsuccessful";
                return result;

            }
        }
        /// <summary>
        /// Allows an administrator to change the queue by overriding the workflow engine.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ToQueue"></param>
        /// <returns></returns>
        public OrderChangeResult Override(OrderChangeRequest request, OrderQueueEnum ToQueue)
        {
            OrderChangeResult result = new OrderChangeResult();
            //TODO: Add code that allows an admin to change order to any queue. Must however log the change in the OrderLog table


            return result;
        }
        /// <summary>
        /// Returns the current order
        /// </summary>
        /// <returns></returns>
        public Order GetOrder()
        {
            return _order;
        }

        /// <summary>
        /// Creates a new order and sets default values
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public Order CreateOrder(NewOrder newOrder)
        {

            string newNote = newOrder.CreateDate.ToString() + " " + newOrder.CreateBy + " >> Order opened | " + "\r\n";

            Order order = new Order();

            order.AssignedTo = newOrder.AssignedTo;
            order.CampaignId = newOrder.CampaignId;
            order.CreateBy = newOrder.CreateBy;
            order.CreateDate = newOrder.CreateDate;
            order.CustomerId = newOrder.CustomerId;
            order.LeadId = newOrder.LeadId;
            order.Notes = newNote;
            order.OrderQueueId = 1; //set the default entry queue 
            order.Owner = newOrder.CreateBy;
            order.TeamId = newOrder.TeamId;
            order.ChangeBy = newOrder.CreateBy;

            db.Orders.Add(order);
            db.SaveChanges();



            return order;


        }


        /// <summary>
        /// OnTransition is fired each time a queue is changed. We use this event to log the tranistion 
        /// </summary>
        /// <param name="transition"></param>
        private void OnTransition(StateMachine<OrderQueueEnum, TriggerEnum>.Transition transition)
        {
            //log the transition

            DateTime changeDate = DateTime.Now;

            //update last log with exit datetime.        

            //find the last log that where destination state equals the new source state and that has no exit date.

            var OrderLogQuery = from st in db.OrderLogs
                                where st.OrderId == _order.Id && st.Destination == (int)transition.Source && st.ExitDate == null
                                orderby st.Id
                                select st;

            var prevOrderLog = OrderLogQuery.FirstOrDefault<OrderLog>();

            if (prevOrderLog != null)
            {
                DateTime prevDate = (DateTime)prevOrderLog.EnterDate;

                TimeSpan dur = (changeDate - prevDate);

                prevOrderLog.ExitDate = changeDate;
                prevOrderLog.MinutesInQueue = (decimal)dur.TotalMinutes;

                db.Entry(prevOrderLog).State = EntityState.Modified;


            }

            //create new log
            OrderLog log = new OrderLog();

            log.ChangeDate = changeDate;
            log.ChangeBy = _orderChange.Username;
            log.OrderId = _order.Id;
            log.Source = (int)transition.Source;
            log.Destination = (int)transition.Destination;
            log.EnterDate = changeDate;
            log.ReasonId = _orderChange.ReasonId;

            db.OrderLogs.Add(log);

            //update the order
            _order.OrderQueueId = (int)transition.Destination;
            _order.OrderQueueChangeDate = changeDate;
            _order.ChangeBy = _orderChange.Username;
            _order.Notes = UpdateNotes(changeDate.ToString());

            db.Entry(_order).State = EntityState.Modified;

            db.SaveChanges();

        }

        /// <summary>
        /// UpdateNotes builds out a notes string for easy reading of order notes.
        /// </summary>
        /// <param name="changeDate"></param>
        /// <returns></returns>
        private string UpdateNotes(string changeDate)
        {

            string currentNote = _order.Notes;

            if (_orderChange.NewNote == null)
            {
                return currentNote;
            }
            else
            {
                string newNote = changeDate + " " + _orderChange.Username + " >> " + _orderChange.NewNote + " | ";
                string updatedNote = currentNote + "\r\n" + newNote;
                return updatedNote;
            }
        }

    }
}