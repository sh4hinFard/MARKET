using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
    public class Details
    {
        public int Id { get; set; }
        public Kala Kala { get; set; }
        public int KalaId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
