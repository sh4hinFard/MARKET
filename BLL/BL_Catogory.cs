using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Be;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL
{
  public  class BL_Catogory
    {
        DL_Catogory DL = new DL_Catogory();
        db db1 = new db();
        public void Create(Catogory catogory)
        {
            DL.Create(catogory);
        }
        public List<Catogory> read ()
        {
          return  DL.read();
        }

        public List<SelectListItem> GetSubGroupManage(int groupId)
        {
            return DL.GetSubGroupManage(groupId);
        }
    }
}
