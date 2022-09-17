using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Froushgah.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(db.SliderRepository.ShowSlider());
        }
    }
}