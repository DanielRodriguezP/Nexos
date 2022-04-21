using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Nexos.Web.Controllers
{
    public class LibroController : Controller
    {
        public ActionResult Libro()
        {
            return View();
        }
    }
}
