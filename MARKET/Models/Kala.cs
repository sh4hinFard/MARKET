using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MARKET.Models
{
    public class Kala
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Count { get; set; }
            public List<int> Color { get; set; }
            public List<int> Size { get; set; }
            public IFormFile Pic { get; set; }
            public int Catogory1 { get; set; }
            public int Catogory { get; set; }
            public int Catogoryreal { get; set; }


    }
}
