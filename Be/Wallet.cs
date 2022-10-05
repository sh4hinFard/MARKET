using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
 public  class Wallet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool IsPay { get; set; }
        public DateTime RegisterDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public WalletType WalletType { get; set; }
        public int WalleTypetId { get; set; }
    }
}
