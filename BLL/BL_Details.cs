using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Be;
namespace BLL
{
  public  class BL_Details
    {
        DL_Details dl = new DL_Details();
        public void Create(Details details)
        {
            dl.Create(details);
        }
    }
}
