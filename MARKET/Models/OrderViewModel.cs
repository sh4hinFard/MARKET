using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int OstanId { get; set; }
        public int zipcode { get; set; }
        public  long Phone { get; set; }
        public int totalprice { get; set; }
        public int PostId { get; set; }
        public int PayId { get; set; }
    }
}
