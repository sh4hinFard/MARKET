using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
   public class Customer
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public City city { get; set; }
        public int cityId { get; set; }
        public Ostan ostan { get; set; }
        public int ostanId { get; set; }
        public int zipcode { get; set; }
        public List<Order> Order { get; set; }
        public long Phone { get; set; }
   }
}
