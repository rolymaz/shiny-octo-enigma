using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TST.Services;
using TST.Services.OrderService;
using TST.SQL;

namespace TST.Controllers
{
    public class NewOrdersController : Controller
    {
        private SalesTrackerDbEntities db = new SalesTrackerDbEntities();

        // GET: NewOrders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: NewOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: NewOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,CampaignId,TeamId,LeadId,CustomerId,CreateBy")] Order order)
        {
            if (ModelState.IsValid)
            {
                //initial orderservice 
                OrderServiceFactory factory = new OrderServiceFactory();
                               

                NewOrder newOrder = new NewOrder();

                newOrder.AssignedTo = order.AssignedTo;
                newOrder.CampaignId = order.CampaignId;
                newOrder.CreateBy = order.CreateBy;
                newOrder.CreateDate = DateTime.Now;
                newOrder.CustomerId = order.CustomerId;
                newOrder.DepartmentId = order.DepartmentId;
                newOrder.LeadId = order.LeadId;
                newOrder.Owner = order.CreateBy;
                newOrder.TeamId = order.TeamId;
                newOrder.WorkflowId = order.WorkflowId;

                IOrderService orderService = factory.StartFactory((WorkflowEnum)order.WorkflowId);

                orderService.CreateOrder(newOrder);
                
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: NewOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: NewOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,CampaignId,TeamId,LeadId,CustomerId,OrderQueueId,OrderQueueChangeDate,CustomerRef,CreateDate,CreateBy,Owner,SeqNo,WorkflowId,ChangeBy,ChangeDate,OrderRef,AccountNo,AssignedTo,OrderPriority,Notes,CancelBy,CancelDate,CancelReasonId,IMEI,MSISDN,ActivationDate,ContractExpiryDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: NewOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: NewOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
