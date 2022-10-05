using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Be;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MARKET.Controllers
{
    public class KalaController : Controller
    {
        private IWebHostEnvironment Environment;
        public KalaController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        BL_Kala_Size blsize = new BL_Kala_Size();
        BL_Kala_Color blcolor = new BL_Kala_Color();
        BL_kala bl = new BL_kala();
        BL_Catogory blc = new BL_Catogory();
        db db1 = new db();
        public IActionResult Create()
        {
            ViewData["Color"] = db1.Colors.ToList();
            ViewData["Size"] = db1.Sizes.ToList();
            //var b = db1.catogories.Where(p=>p.ParentId == null).ToList();
            //foreach (var i in b)
            //{
                ViewData["Catogory1"] = new SelectList(db1.catogories.Where(i => i.ParentId == null).ToList(), "Id", "Title");
            //    var g = db1.catogories.Where(o => o.ParentId == i.Id).ToList();
            //    ViewData["Catogory2"] = new SelectList(db1.catogories.Where(i => i.ParentId == i.Id).ToList(), "Id", "Title");          
            //    foreach (var item in g)
            //    {
            //        ViewData["Catogory3"] = new SelectList(db1.catogories.Where(i => i.ParentId == item.Id).ToList(), "Id", "Title");
            //    }
            //}
            return View();
        }

public IActionResult GetSubGroupByGroupId(int id)
        {
            List<SelectListItem> subGroupItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",
                    Text="انتخاب کنید"
                }
            };
            var subGroup = blc.GetSubGroupManage(id);
            subGroupItems.AddRange(subGroup);
            return Json(new SelectList(subGroupItems,"Value","Text"));
        }


        [HttpPost]
        public IActionResult Create(Models.Kala k)
        {
            if (k.Catogory1 != 0 & k.Catogory != 0 & k.Catogoryreal != 0)
            {
                var color = new List<kala_color>();
                var Size = new List<Kala_Size>();
                Kala_Size size = new Kala_Size();
                Be.Kala kala = new Be.Kala();
                kala.Name = k.Name;
                kala.Price = k.Price;
                kala.Count = k.Count;
                kala.CatogoryId = k.Catogoryreal;
                UploadFile upf = new UploadFile(Environment);
                kala.Pic = upf.upload(k.Pic);

                bl.Create(kala);
                foreach (var item in k.Color)
                {
                    color.Add(new kala_color()
                    {
                        ColorId = item,
                        KalaId = kala.Id
                    });
                }
                blcolor.create(color);

                foreach (var item in k.Size)
                {
                    Size.Add(new Kala_Size()
                    {
                        SizeId = item,
                        KalaId = kala.Id
                    });
                }
                blsize.Create(Size);
                ViewData["RoleId"] = new SelectList(db1.catogories.ToList(), "Id", "Title", "Detail");
                ViewData["Color"] = db1.Colors.ToList();
                ViewData["Size"] = db1.Sizes.ToList();
                ViewData["Catogory1"] = new SelectList(db1.catogories.Where(i => i.ParentId == null).ToList(), "Id", "Title");
            }
            else
            {
              return Json("fill all");
            }
                return View();
        }
        public IActionResult Update(int Id)
        {
            var model = db1.kalas.Find(Id);
            ViewData["RoleId"] = new SelectList(db1.catogories.ToList(), "Id", "Title","Detail");
            return View(model);
        }
        [HttpPost]
        public IActionResult update(int id, Models.Kala k)
        {
            Be.Kala kala = new Be.Kala();

            kala.Name = k.Name;
            kala.Price = k.Price;
            kala.Count = k.Count;
            kala.CatogoryId = k.Catogory;
            UploadFile upf = new UploadFile(Environment);
            kala.Pic = upf.upload(k.Pic);
            bl.Update(id,kala);
            var l = bl.getskip(0);

            return View("ListKala",l);
        }
        public IActionResult ListKala(int pageId = 1)
        {           
            ViewData["RoleId"] = new SelectList(db1.catogories.ToList(),"Id", "Title", "Detail");
            int skip = (pageId - 1) * 10;
            ViewBag.PageId = pageId;
            double count = db1.kalas.ToList().Count();
            ViewBag.item = count;
            ViewBag.Count = Math.Ceiling(count / 10);
            return View(db1.kalas.Include(i=>i.Color).Include(i=>i.Size).Include(i=>i.Catogory).Skip(skip).Take(10).ToList());
        }
        public IActionResult getskip(int c)
        {
            return View("ListKala", bl.getskip(c));
        }
        public IActionResult skip()
        {
          var list = db1.kalas.OrderBy(i => i.Id).Skip(0).Take(10).Include(i => i.Catogory).ToList();
            return View("ListKala", list);
        }
        public IActionResult search(string text)
        {
            if (text != null)
            {
                var bb = bl.search(text);
                return View("ListKala", bb);
            }
            else
            {
                var a = bl.getskip(0);
                return View("ListKala", a);
            }
        }
        [HttpGet]
        public IActionResult delet(int id)
        {
            var b = db1.kalas.Find(id);
            db1.Remove(b);
            db1.SaveChanges();
            var a = db1.kalas.ToList();
            return Json(a);
        }

        public ActionResult Index(int pageId = 1)
        {
            ViewData["RoleId"] = new SelectList(db1.catogories.ToList(), "Id", "Title", "Detail");
            int skip = (pageId - 1) * 10;
            ViewBag.PageId = pageId;
            double count = db1.kalas.ToList().Count();
            ViewBag.item = count;
            ViewBag.Count = Math.Ceiling(count / 10);
            return View("ListKala",db1.kalas.ToList().Skip(skip).Take(10).ToList());
        }

    }
}
