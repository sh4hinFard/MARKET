using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Be
{
 public  class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
