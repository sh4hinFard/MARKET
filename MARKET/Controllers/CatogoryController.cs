using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Be;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MARKET.Controllers
{
    public class CatogoryController : Controller
    {
        db db1 = new db();
        BL_Catogory bl = new BL_Catogory();

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Catogory"] = new SelectList(db1.catogories.Where(i => i.ParentId == null).ToList(), "Id", "Title");
            ViewData["CatogoryP"] = new SelectList(db1.catogories.Where(i => i.ParentId != null).ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CatogoryViewModel c)
        {
            Catogory catogory = new Catogory();
           
            if(c.ParentId ==0)
            {
                c.ParentId = null;
                catogory.Title = c.Title;
                catogory.ParentId = c.ParentId;
                bl.Create(catogory);
            }
            if (c.ParentId != null&&c.Id ==0)
            {
                catogory.Title = c.Title;
                catogory.ParentId = c.ParentId;
                bl.Create(catogory);
            }
            if(c.ParentId !=null&&c.Id!=0)
            {
                catogory.Title = c.Title;
                catogory.ParentId = c.Id;
                bl.Create(catogory);
            }

            ViewData["Catogory"] = new SelectList(db1.catogories.Where(i => i.ParentId == null).ToList(), "Id", "Title");
             ViewData["CatogoryP"] = new SelectList(db1.catogories.Where(i => i.ParentId != null).ToList(), "Id", "Title");
                return View();
        }

  


    }
}
