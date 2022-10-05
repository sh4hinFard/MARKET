using System;
using System.Collections.Generic;
using System.Text;
using Be;
using DAL;
namespace BLL
{
 public   class BL_order
    {
        DL_Order dl = new DL_Order();
        public  void Create(Order order)
        {
            dl.Create(order);
        }

        public void Update(Order order)
        {
            dl.Update(order);
        }
        public List<Order> read(string Name, string Family, int Id, int Number, String Email)
        {
            return dl.read(Name, Family, Id, Number, Email);
        }
    }
}
