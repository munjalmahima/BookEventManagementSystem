using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEventManagement.Models;
using Nagarro.BookEventManagement.Shared;

namespace BookEventManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            List<EventDTO> list = eventFacade.GetEvents();
            var viewModel = new EventViewModel
            {
                Events = list
            };
            return View(list);

        }
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}