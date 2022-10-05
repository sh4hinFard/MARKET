using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MARKET.Models
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile
        {
            get; set;
        }
    }
}
