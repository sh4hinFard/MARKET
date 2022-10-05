using System;
using System.Collections.Generic;
using System.Text;
using Be;
using DAL;
namespace BLL
{
   public class BL_Kala_Size
    {
        DL_Kala_Size dl = new DL_Kala_Size();
        public void Create(List<Kala_Size> size)
        {
            dl.Create(size);
        }
    }
}
