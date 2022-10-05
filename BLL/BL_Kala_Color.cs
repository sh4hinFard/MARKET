using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Be;
namespace BLL
{
   public class BL_Kala_Color
    {
        DL_Kala_Color dl = new DL_Kala_Color();
        public void create(List<kala_color> color)
        {
            dl.create(color);
        }
    }
}
