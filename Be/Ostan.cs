using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
  public class Ostan
  {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> order { get; set; }
        public List<Customer> customers { get; set; }
    }
}
