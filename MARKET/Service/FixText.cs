using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Service
{
    public static class FixText
    {
        public static string FixEmail(string email)
        {
          return email.ToLower().Trim();
           
        }
    }
}
