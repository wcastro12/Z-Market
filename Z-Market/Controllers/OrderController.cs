using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z_Market.Models;
using Z_Market.ViewModels;

namespace Z_Market.Controllers
{
    public class OrderController : Controller
    {
        private Z_MarketContext db = new Z_MarketContext();
        // GET: Order
        public ActionResult NewOrder()
        {
            OrderView orderview;
            if (Session["Orderview"] == null)
            {
                orderview = new OrderView();
                orderview.Custumer = new Custumer();
                orderview.Productos = new List<ProductOrder>();

                Session["Orderview"] = orderview;
            }
            else
            {
                orderview = Session["Orderview"] as OrderView;
            }

            var lcustumer = db.Custumers.ToList();
            lcustumer.Add(new Custumer() { CustumerId = 0, Name = "...Selecciona un cliente" });

            ViewBag.CustumerId = new SelectList(lcustumer, "CustumerId", "Name");

            return View(orderview);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderview)
        {
            var ordervieworigen = Session["Orderview"] as OrderView;
            var CustumerId = int.Parse(Request["CustumerId"]);
            if (CustumerId == 0)
            {
                var lcustumers = db.Custumers.ToList();
                lcustumers.Add(new Custumer() { CustumerId=0,Name= "...Selecciona un cliente"});
                ViewBag.CustumerId = new SelectList(lcustumers, "ProductoId", "Name");
                ViewBag.error = "Debe seleccinar un Cliente";
                return View(orderview);
            }

            var Custumer = db.Custumers.Find(CustumerId);
            if (Custumer == null)
            {
                var lcustumers = db.Custumers.ToList();
                lcustumers.Add(new Custumer() { CustumerId = 0, Name = "...Seleccione un cliente" });
                ViewBag.CustumerId = new SelectList(lcustumers, "ProductoId", "Name");

                ViewBag.error = "El cliente no existe";
                return View(orderview);
            }

            if (ordervieworigen.Productos.Count==0)
            {
                var lcustumers = db.Custumers.ToList();
                lcustumers.Add(new Custumer() { CustumerId = 0, Name = "...Seleccione un cliente" });

                ViewBag.error = "Debe ingresar detalle";
                return View(orderview);
            }
            var order = new Order()
            {
                CustumerId = CustumerId,
                 DateOrder=DateTime.Now,
                 StatuOrder=Statu.Create
            };

            db.Order.Add(order);
            db.SaveChanges();

            var orderid = db.Order.ToList().Select(o => o.OrderId).Max();

            foreach (var item in ordervieworigen.Productos)
            {
                var po = new OrderDetail()
                {
                    Description = item.Description,
                    Price = item.Price,
                    Quantity = item.Quantity,
                   OrderId= orderid,
                   ProductoId=item.ProductoId

                };
                db.OrderDetail.Add(po);
            }
            db.SaveChanges();
            Session["Orderview"] = null;
            ViewBag.Message = string.Format("La orden: {0}, grabada ok ",orderid);
            return RedirectToActionPermanent("NewOrder",ViewBag);
        }

   
        public ActionResult AddProduct()
        {

            ViewBag.ProductoId = new SelectList(db.Productoes.ToList(), "ProductoId", "Name");
           

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {

            var Ow = Session["Orderview"] as OrderView;

            var productId = int.Parse(Request["ProductoId"]);
            if (productId == 0)
            {
                ViewBag.ProductoId = new SelectList(db.Productoes.ToList(), "ProductoId", "Name");
                ViewBag.error = "Debe seleccinar un producto";
                return View(productOrder);
            }
            var Quantity = int.Parse(Request["Quantity"]);
            if (Quantity == 0)
            {
                ViewBag.ProductoId = new SelectList(db.Productoes.ToList(), "ProductoId", "Name");
                ViewBag.error = "Debe seleccinar ingresa una cantidad";
                return View(productOrder);
            }

            ProductOrder productorder = Ow.Productos.Find(a => a.ProductoId == productId);
            if (productorder == null)
            {
                var prod = db.Productoes.Find(productOrder.ProductoId);
                productorder = new ProductOrder()
                {
                    Description = prod.Description,
                    Name = prod.Name,
                    Quantity = float.Parse(Request["Quantity"]),
                    Price = prod.Price,
                    ProductoId = prod.ProductoId
                };
                Ow.Productos.Add(productorder);
            }
            else
            {
                productorder.Quantity += float.Parse(Request["Quantity"]);
            }
        

            return RedirectToAction("NewOrder");

        }

        private OrderView AddSeccion(ProductOrder p)
        {
            if (Session["lproduc"] != null)
            {
                OrderView lproduc = (OrderView)Session["lproduc"];
                lproduc.Productos.Add(p);
                Session.Add("lproduc", lproduc);
            }
            else
            {
                List<Producto> lproduc =new List<Producto>() { p};
                //lproduc.Add(p);
                Session.Add("lproduc", lproduc);
            }
            return (OrderView)Session["lproduc"];
        }

        private void saveorden(int idc )
        {
            var orderview = Session["Orderview"] as OrderView;
            var orden = new Order
            {
                DateOrder = DateTime.Now,
                StatuOrder = Statu.Create,
                CustumerId = orderview.Custumer.CustumerId

            };
            db.Order.Add(orden);
            db.SaveChanges();
           var IdOder = db.Order.ToList().Select(o => o.CustumerId).Max();
            foreach (ProductOrder item in orderview.Productos)
            {
                db.OrderDetail.Add(new OrderDetail()
                {
                    OrderId = IdOder,
                    ProductoId = item.ProductoId

                });
            }
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}