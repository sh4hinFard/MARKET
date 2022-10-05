using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class WalletViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsPay { get; set; }
        public DateTime RegisterDate { get; set; }
        public int TypeId { get; set; }
        public int Amount { get; set; }

    }
}
