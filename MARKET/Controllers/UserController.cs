using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Be;
using DAL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace MARKET.Controllers
{
    public class UserController : Controller
    {
        BLL.BL_kala bl = new BLL.BL_kala();
        db db1 = new db();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product_Page(int Id)
        {
            var model = db1.kalas.Where(i => i.Id == Id).Include(i => i.Size).Include(i => i.Color).SingleOrDefault();          
            ViewBag.Size = db1.Kala_Size.Where(i => i.KalaId == Id).Include(i => i.Size).ToList();
            ViewBag.Color = db1.Kala_Color.Where(i => i.KalaId == Id).Include(i => i.Color).ToList();
            return View(model);
        } 
        public IActionResult Shop(int Id, int pageId = 1)
        {          
            ViewData["RoleId"] = new SelectList(db1.catogories.ToList(), "Id", "Title");
            ViewData["Color"] = db1.Colors.ToList();
            ViewData["Size"] = db1.Sizes.ToList();
            int skip = (pageId - 1) * 5;
            ViewBag.PageId = pageId;
            double count = db1.kalas.ToList().Count();
            ViewBag.item = count;
            ViewBag.Count = Math.Ceiling(count / 5);
            var model = db1.kalas.Where(i=>i.CatogoryId == Id).ToList().Skip(skip).Take(5).ToList();
            ViewBag.Id = Id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Filter(int catogryId, List<int> color, List<int> size, int min, int max)
        {
            ViewBag.Kala = bl.Filter(catogryId, color, size, min, max);
            ViewData["RoleId"] = new SelectList(db1.catogories.ToList(), "Id", "Title");
            ViewData["Color"] = db1.Colors.ToList();
            ViewData["Size"] = db1.Sizes.ToList();
            return View("Shop");
        }
    }
}
