using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Be;
namespace BLL
{
 public   class BL_Customer
    {
        DL_Customer dl = new DL_Customer();
        public void Create(Customer customer)
        {
            dl.Create(customer);
        }
    }
}
