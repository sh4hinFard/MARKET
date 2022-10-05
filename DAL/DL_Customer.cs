using System;
using System.Collections.Generic;
using System.Text;
using Be;
namespace DAL
{
  public  class DL_Customer
    {
        db db1 = new db();
        public void Create(Customer customer)
        {
            db1.Customer.Add(customer);
            db1.SaveChanges();
        }
    }
}
