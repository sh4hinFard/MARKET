using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class CatogoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
}
