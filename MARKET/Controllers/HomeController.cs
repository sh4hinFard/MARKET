using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using MARKET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZarinpalSandbox;

namespace MARKET.Controllers
{
    public class HomeController : Controller
    {
        db db1 = new db();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Kalas") != null)
            {
                //var model = new List<Models.SessionKalaViewModel>();
                ViewBag.Items = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
                //var model = q.First().Id;
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Index(int Id, string Name, string Pic, int Price, int Count, int SizeId, int ColorId, string Color, String Size)
        {

            List<Models.SessionKalaViewModel> sessionKalaViewModel = new List<Models.SessionKalaViewModel>();
            //var q = new List<Models.SessionKalaViewModel>();
            if (HttpContext.Session.GetString("Kalas") != null)
            {
                sessionKalaViewModel = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
                var Kala = sessionKalaViewModel.ToList();

                if (Kala != null & Kala.Any(i => i.Id == Id))
                {
                    foreach (var item in sessionKalaViewModel.Where(i => i.Id == Id))
                    {

                        item.Count += Count;
                        item.Sum = item.Price * item.Count;
                    }
                }

                else
                {

                    sessionKalaViewModel.Add(new Models.SessionKalaViewModel()
                    {
                        Id = Id,
                        Name = Name,
                        Count = Count,
                        Pic = Pic,
                        Price = Price,
                        Color = Color,
                        Size = Size,
                        SizeId = SizeId,
                        ColorId = ColorId,
                        Sum = sessionKalaViewModel.Sum(i => i.Price * i.Count)
                    });
                }
            }
            else
            {
                sessionKalaViewModel.Add(new Models.SessionKalaViewModel()
                {
                    Id = Id,
                    Name = Name,
                    Count = Count,
                    Pic = Pic,
                    Price = Price,
                    Color = Color,
                    Size = Size,
                    SizeId = SizeId,
                    ColorId = ColorId
                    //Sum = sessionKalaViewModel.Sum(i => i.Price * i.Count)
                });

                foreach (var i in sessionKalaViewModel)
                {
                    i.Sum = i.Price * i.Count;
                }

            }

            HttpContext.Session.SetString("Kalas", JsonConvert.SerializeObject(sessionKalaViewModel));
            //var model = new List<Models.SessionKalaViewModel>();
            ViewBag.Items = JsonConvert.DeserializeObject<List<Models.SessionKalaViewModel>>(HttpContext.Session.GetString("Kalas"));
            //var model = q.First().Id;
            return RedirectToAction("Product_Page", "User", new { Id = Id });
        }
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = db1.Orders.Find(id);
                var payment = new Payment(order.TotalPrice);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    db1.Orders.Update(order);
                    db1.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
               

            }
            return BadRequest();
        }
    }
}
