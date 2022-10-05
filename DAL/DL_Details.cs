using System;
using System.Collections.Generic;
using System.Text;
using Be;
namespace DAL
{
  public  class DL_Details
    {
        db db1 = new db();
        public void Create(Details details)
        {
            db1.Details.AddRange(details);
            db1.SaveChanges();
        }

    }
}
