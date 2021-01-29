using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indiano.Controllers
{
    public class ViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
