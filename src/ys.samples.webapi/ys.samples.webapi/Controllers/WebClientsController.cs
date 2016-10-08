using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ys.samples.webapi.Controllers
{
    public class WebClientsController : Controller
    {
        // GET: WebClients
        public ActionResult Index()
        {
            // var view = new FilePathResult()
            return View();
        }
        public ActionResult DevCafe( ) {
            var view = new FilePathResult("devcafe/app/index.html", "text/html");
            return view;
        }
    }
}