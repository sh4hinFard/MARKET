using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Be;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAL
{
   public class DL_Catogory
    {
        db db1 = new db();

        public void Create(Catogory catogory)
        {
            db1.catogories.Add(catogory);
            db1.SaveChanges();
        }
        public List<Catogory> read()
        {
            return db1.catogories.ToList();
        }
        public List<SelectListItem> GetSubGroupManage(int groupId)
        {
            return db1.catogories.Where(g => g.ParentId == groupId).Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.Id.ToString()
            }).ToList();
        }
    }
}
