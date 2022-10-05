using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Be
{
    public class Catogory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }       
        public List <Catogory> catogory { get; set; }
        public Catogory catogorys { get; set; }
        [ForeignKey("catogorys")]
        public int? ParentId { get; set; }
        public List<Kala> Kala { get; set; }
    }
}
