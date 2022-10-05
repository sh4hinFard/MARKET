using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
  public class City
  {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Order> order { get; set; }
        public List<Customer> customers { get; set; }
    }
}
