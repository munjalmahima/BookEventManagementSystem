using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.BookEventManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
    }
}