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
        public ParkController(IParkDAL dal)
        {
            this.dal = dal;
        }
        public ActionResult Detail(string id)
        {
            Park p = new Park();
            var park = dal.GetAllParks().Find(x => x.ParkCode == id);
            return View("Detail", park);
        }
    }
}

