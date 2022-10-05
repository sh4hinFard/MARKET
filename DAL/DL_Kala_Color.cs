using System;
using System.Collections.Generic;
using System.Text;
using Be;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
   public class DL_Kala_Color
   {
        db db1 = new db();
        public void create(List<kala_color> color)
        {
            db1.Kala_Color.AddRange(color);
            db1.SaveChanges();
        }
   }
}
