using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarktSys_ASP_NET_CORE.Controllers
{
    public class AdministrativoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}