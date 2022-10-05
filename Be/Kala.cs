using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Be
{
    public class Kala
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public List<kala_color> Color { get; set; }
        public List<Kala_Size> Size { get; set; }
        public string Pic { get; set; }
        public Catogory Catogory { get; set; }
        [ForeignKey("Catogory")]
        public int? CatogoryId { get; set; }
        public List<Details> Details { get; set; }
    }
}
