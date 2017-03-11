using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class FiveDayForecast
    {
        private IWeatherDAL dal;

        public FiveDayForecast(IWeatherDAL dal, string id)
        {
            this.dal = dal;
            this.Id = id;
            fiveDayForecast = dal.GetForecast(id);
        }

        List<Forecast> fiveDayForecast;

        public string Id { get; set; }


        public bool IsFahrenheit { get; set; }
   
        public List<Forecast> GetForecast(string id)
        {
            List<Forecast> list = dal.GetForecast(id);
            return list;
        }

        //public string GetId()
        //{
        //    string id = "";
        //    foreach(Forecast forecast in fiveDayForecast)
        //    {
        //        id = forecast.ParkCode;
        //    }
        //    return id;
        //}

        public double GetTempInCelsius(double temp)
        {
            double tempInCelsius = ((temp - 32) * (double)(.56));
            return tempInCelsius;
        }
    }
}     


