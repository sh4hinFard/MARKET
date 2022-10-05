using System;
using System.Collections.Generic;
using System.Text;
using Be;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
   public class DL_Kala_Size
   {
        db db1 = new db();
        public void Create(List<Kala_Size> size)
        {
            db1.Kala_Size.AddRange(size);
            db1.SaveChanges();
        }
   }
}
