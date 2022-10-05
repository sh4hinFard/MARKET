using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
   public class TypeOfPay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pardakht> pardakhts { get; set; }
    }
}
