using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BLL;
using DAL;
using Be;
using System.Threading.Tasks;
using ZarinpalSandbox;
using Microsoft.EntityFrameworkCore;

namespace MARKET.Controllers
{
    public class OrderController : Controller
    {
      

        db db1 = new db();
        public IActionResult Checkout()
        {
            var model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            return View(model);
        }

        public IActionResult Delete(int Id)
        {

            var model = new List<Models.SessionKalaViewModel>();
            model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));

            if (HttpContext.Session.GetString("Kalas") != null)
            {
                model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            }
            var f = model.FirstOrDefault(t => t.Id == Id);
            model.Remove(f);
            HttpContext.Session.Remove("Kalas");
            HttpContext.Session.SetString("Kalas", JsonConvert.SerializeObject(model));
            if (model.Count == 0)
            {
                HttpContext.Session.Remove("Kalas");
                return RedirectToAction("Index", "Home");
            }

            return View("Checkout", model);
        }

        public IActionResult Finalized()
        {
            var model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            ViewBag.Post = db1.posts.ToList();
            ViewBag.Typeofpay = db1.typeOfPays.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int Id, int count)
        {
            var model = new List<Models.SessionKalaViewModel>();
            model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            var item = model.SingleOrDefault(i => i.Id.Equals(Id));
            if (item != null && count != 0)
            {
                model.Add(new Models.SessionKalaViewModel
                {
                    Count = count,
                    Pic = item.Pic,
                    Name = item.Name,
                    Price = item.Price,
                    Id = item.Id,

                });
            }

            foreach (var i in model)
            {
                i.Sum = i.Price * i.Count;
            }

            if (model.Count == 0)
            {
                HttpContext.Session.Remove("Kalas");
                return RedirectToAction("Index", "Home");
            }

            model.Remove(item);
            HttpContext.Session.Remove("Kalas");
            HttpContext.Session.SetString("Kalas", JsonConvert.SerializeObject(model));
            model = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            return View("Checkout", model);
        }

        [HttpPost]
        public IActionResult FinalyAsync(Models.OrderViewModel orderView)
        {
            BL_order bL_Order = new BL_order();
            Order_Post post = new Order_Post();
            Pardakht pardakht = new Pardakht();
            var kalas = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            var order = new Be.Order();
            var customer = new Be.Customer();
            var rizf = new Details();
            customer.Name = orderView.Name;
            customer.Family = orderView.Family;
            customer.Email = orderView.Email;
            customer.Address = orderView.Address;
            customer.cityId = orderView.CityId;
            customer.ostanId = orderView.OstanId;
            customer.zipcode = orderView.zipcode;
            customer.Phone = orderView.Phone;
            BL_Customer bL_Customer = new BL_Customer();
            bL_Customer.Create(customer);     
             var user = db1.users.Where(i => i.username == User.Identity.Name).SingleOrDefault();
            order.CustomerId = customer.Id;
            order.cityId = orderView.CityId;
            order.ostanId = orderView.OstanId;
            order.Date = System.DateTime.Now;
            order.IsFinaly = false;
            order.UserId = user.Id;
            order.TotalPrice = orderView.totalprice;

            bL_Order.Create(order);

            //if (Password != null)
            //{

            //    var user = new Be.User()
            //    {

            //        username = username,
            //        email = Email
            //    };
            //    var hash = Models.PasswordHash.EncodePasswordMd5(Password);
            //    var result = await _userManager.CreateAsync(user, hash);
            //    db1.users.Add(user);
            //   await db1.SaveChangesAsync();
            //    order.UserId = user.Id;
            //    order.CustomerId = customer.Id;
            //    order.cityId = CityId;
            //    order.ostanId = OstanId;
            //    order.Date = System.DateTime.Now;
            //    order.TotalPrice = kalas.Sum(i => i.Price * i.Count);
            //    bL_Order.Create(order);

            //}

            foreach (var item in kalas)
            {
                rizf.KalaId = item.Id;
                rizf.OrderId = order.Id;
                BL_Details bL_Details = new BL_Details();
                bL_Details.Create(rizf);
            }

            post.OrderId = order.Id;
            post.PostId = orderView.PostId;

            pardakht.orderId = order.Id;
            pardakht.typeId = orderView.PayId;

            ViewBag.Post = db1.posts.ToList();
            ViewBag.Typeofpay = db1.typeOfPays.ToList();
            HttpContext.Session.Remove("Kalas");
            return RedirectToAction("Payment","Order",new {Id = order.Id } );
        }

        public IActionResult Payment(int Id)
        {
            var order = db1.Orders.Where(o => o.Id == Id).Include(i=>i.Customer).Include(i=>i.User).SingleOrDefault();
            
            if (order == null)
            {
                return NotFound();
            }

            var payment = new Payment(order.TotalPrice);
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.Id}",
                "https://localhost:44330/Home/OnlinePayment/" + order.Id, order.Customer.Email, order.Customer.Phone.ToString());
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

           
        }

        public IActionResult ListOrders()
        {
            var model = db1.Orders.Include(i => i.Customer).ToList();
            return View(model);
        }

        public IActionResult EditOrder(int Id)
        {
            var model = db1.Orders.Where(i => i.Id == Id).Include(i => i.Customer).SingleOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditOrdr(int Id, string Name, string Family, string Email, string Address, int CityId, int OstanId, int zipcode, int Number)
        {
            var q = db1.Orders.Where(i => i.Id == Id).Include(i => i.Customer).SingleOrDefault();
            q.Customer.Name = Name;
            q.Customer.Family = Family;
            q.Customer.Email = Email;
            q.Customer.Address = Address;
            q.cityId = CityId;
            q.ostanId = OstanId;
            q.Customer.zipcode = zipcode;
            q.Customer.Phone = Number;
            BL_order bL_Order = new BL_order();
            bL_Order.Update(q);
            return View();
        }
        [HttpPost]
        public IActionResult sumtotal(int Price,int Sum)
        {
            var data = Price + Sum;      
            return Json(data);
        }
    }
}
