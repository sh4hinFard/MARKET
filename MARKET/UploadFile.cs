using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MARKET
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webhostenviroment = webHostEnvironment;
        }
        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\images\\product\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;

        }
    }
}
