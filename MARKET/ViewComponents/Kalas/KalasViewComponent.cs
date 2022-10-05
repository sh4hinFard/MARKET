using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MARKET.ViewComponents.Kalas
{
    public class KalasViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL.BL_kala bl = new BLL.BL_kala();
            var Kalas = bl.read();
            return View("Kalas", Kalas);
        }
    }
}
