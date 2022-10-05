using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Be
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public City city { get; set; }
        public int? cityId { get; set; }
        public Ostan ostan { get; set; }
        public int? ostanId { get; set; }
        public bool IsFinaly { get; set; }
        public  User User {get; set; }
        public int? UserId { get; set; }
        public List<Pardakht> Pardakhts { get; set; }
        public List<Details> Details { get; set; }
        public List<Order_Post> order_Posts { get; set; }

    }
}
