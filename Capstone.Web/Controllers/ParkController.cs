using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        private readonly IParkDAL dal;
        private readonly IWeatherDAL weatherDal;
        public ParkController(IParkDAL dal, IWeatherDAL weatherDal)
        {
            this.dal = dal;
            this.weatherDal = weatherDal;
        }
        public ActionResult Detail(string id)
        {
            Park p = new Park();
            var park = dal.GetAllParks().Find(x => x.ParkCode == id);
            return View("Detail", park);
        }
        public ActionResult Forecast(string id)
        {

            var forecast = weatherDal.GetForecast(id);
            return View("Forecast", forecast);
        }
        [HttpPost]
        public ActionResult Forecast()
        {
            return View();
        }
    }
}

