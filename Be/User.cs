using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Be
{
 public  class User
    {
       
        public int  Id { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String ActiveCode { get; set; }
        public String UserImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegisterDate { get; set; }
        public String password { get; set; }
        public String GenerateCode { get; set; }
        public List<Order> order { get; set; }
        public virtual Roles Role { get; set; }
        public int RoleId { get; set; }
        public List<Wallet> wallets { get; set; }
      
    }
}
