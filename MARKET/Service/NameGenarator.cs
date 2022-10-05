using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Service
{
    public static class NameGenarator
    {
        public static string NameGeneratedUniq()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
