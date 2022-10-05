using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AmountWallet { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
