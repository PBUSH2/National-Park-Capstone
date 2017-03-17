using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=npgeek;User ID=te_student;Password=sqlserver1";

        [TestMethod()]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            //Arrange
           
            IParkDAL dal = new ParkSqlDAL(connectionString);
            HomeController controller = new HomeController(dal);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod()]
        public void ParkController_DetailAction_ReturnDetailView()
        {
            //Arrange
            IParkDAL parkDal = new ParkSqlDAL(connectionString);
            IWeatherDAL weatherDal = new WeatherSqlDAL(connectionString);

            ParkController controller = new ParkController(parkDal, weatherDal);

            //Act
            ViewResult result = controller.Detail("CVNP") as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Detail", result.ViewName);
            
        }
        [TestMethod()]
        public void SurveyController_IndexAction_ReturnIndexView()
        {
            //Arrange
            ISurveyDAL surveyDal = new SurveySqlDAL(connectionString);
            SurveyController controller = new SurveyController(surveyDal);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod()]
        public void Forecast_ReturnsCorrectViewAndModel()
        {
            //Arrange
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=npgeek;User ID=te_student;Password=sqlserver1";
            IParkDAL parkDAL = new ParkSqlDAL(connectionString);
            IWeatherDAL weatherDAL = new WeatherSqlDAL(connectionString);
            ParkController controller = new ParkController(parkDAL, weatherDAL);

            //Act
            ViewResult result = controller.Forecast("CVNP", "Cuyahoga Valley National Park") as ViewResult;

            //Assert
            Assert.IsNotNull(result);


        }
    }
}