using System;
using System.Collections.Generic;
using System.Text;

namespace Be
{
   public class WalletType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wallet> wallets { get; set; }
    }
}
