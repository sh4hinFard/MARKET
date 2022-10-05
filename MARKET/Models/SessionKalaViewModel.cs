using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class SessionKalaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public string Color{ get; set; }
        public string Size{ get; set; }
        public int Sum { get; set; }
    }

}
