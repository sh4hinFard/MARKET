using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Be;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL
{
    public class DL_Order
    {
        db db1 = new db();
        public  void Create(Order order)
        {
          db1.Orders.Add(order);
          db1.SaveChanges();
        }

        public void Update(Order order)
        {
            db1.Update(order);
            db1.SaveChanges();
        }

        public List<Order> read(string Name,string Family,int Id,int Number,String Email)
        {
            return db1.Orders.Where(i => i.Customer.Name == Name && i.Customer.Family == Family || i.Id == Id || i.Customer.Phone == Number || i.Customer.Email == Email).ToList();
        }
    }
}
