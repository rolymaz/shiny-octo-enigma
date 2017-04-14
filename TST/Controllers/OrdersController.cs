using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TST.Models;
using TST.Services;
using TST.Services.OrderService;
using TST.Data;

namespace TST.Controllers
{
    public class OrdersController : Controller
    {
        private SalesTrackerDbEntities db = new SalesTrackerDbEntities();

        // GET: Order
        public ActionResult Index(int? orderId)
        {

            if (orderId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderModel model = new OrderModel();

            model.OrderLogs = db.OrderLogs.Where(m =>m.OrderId ==orderId).ToList();

            model.Order = db.Orders.Find(orderId);





            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLog orderLog = db.OrderLogs.Find(id);
            if (orderLog == null)
            {
                return HttpNotFound();
            }
            return View(orderLog);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,Source,Destination,Result,ChangeDate,ChangeBy")] OrderLog orderLog)
        {
            if (ModelState.IsValid)
            {
                db.OrderLogs.Add(orderLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderLog);
        }

        public ActionResult ChangeOrder()
        {
            ViewBag.Message = "Orders Test Page";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeOrder(OrderChangeRequestModel orderChangeRequest)
        {
            if (ModelState.IsValid)
            {
                //hardcoded for now:
                orderChangeRequest.WorkFlowType = WorkflowEnum.ConsumerMobile;


                //initial orderservice 
                OrderServiceFactory factory = new OrderServiceFactory();

                IOrderService orderService = factory.StartFactory(orderChangeRequest.WorkFlowType);

                orderService.StartService(orderChangeRequest.ChangeRequest);

                
                switch (orderChangeRequest.Trigger)
                {
                    case TriggerEnum.Open:
                        orderService.Open();
                        break;

                    case TriggerEnum.Pass:
                        orderService.Pass();
                        break;
                   

                    case TriggerEnum.Fail:
                        orderService.Fail();
                        break;

                    case TriggerEnum.Cancel:
                        orderService.Cancel();
                        break;

                    case TriggerEnum.Close:
                        orderService.Close();
                        break;

                    default:
                        break;
                }


                return RedirectToAction("Index", new { orderId = orderChangeRequest.ChangeRequest.OrderId });
            }

            return View(orderChangeRequest);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLog orderLog = db.OrderLogs.Find(id);
            if (orderLog == null)
            {
                return HttpNotFound();
            }
            return View(orderLog);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,Source,Destination,Result,ChangeDate,ChangeBy")] OrderLog orderLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderLog);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLog orderLog = db.OrderLogs.Find(id);
            if (orderLog == null)
            {
                return HttpNotFound();
            }
            return View(orderLog);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLog orderLog = db.OrderLogs.Find(id);
            db.OrderLogs.Remove(orderLog);
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
