using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
   public class Post
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Order_Post> order_Posts { get; set; }

    }
}
