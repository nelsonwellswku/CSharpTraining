using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicTacToeWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index(string name, string age)
        {
            ViewBag.Title = "asdfsadfasfd";
            ViewBag.ThisDontExist = "asdasdffds";
            return View();
        }

    }
}
