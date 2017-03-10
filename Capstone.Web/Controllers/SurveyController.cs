using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDal;

        // GET: Survey
        public SurveyController(ISurveyDAL surveyDal)
        {
            this.surveyDal = surveyDal;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Survey survey)
        {
            surveyDal.SaveSurvey(survey);
            return RedirectToAction("SurveyResult", "Survey");
        }
        public ActionResult SurveyResult()
        {
            string topPark = surveyDal.FindTopPark();
            return View("SurveyResult", (object)topPark);
        }
    }
}
