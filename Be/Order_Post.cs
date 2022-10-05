using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
  public  class Order_Post
    {
        public int Id { get; set; }
        public Order order { get; set; }
        public Post post { get; set; }
        public int PostId { get; set; }
        public int OrderId { get; set; }
    }
}
