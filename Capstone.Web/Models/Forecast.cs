using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        //public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public double FiveDayForecastValue { get; set; }
        public double Low { get; set; }
        public int High { get; set; }
        public string ForeCast { get; set; }
 
        public string RecommendedAction()
        {
            string one = "";
            string two = "";
            string three = "";
            string four = "";

            if (ForeCast == "snow")
            {
                one = "Pack Snowshoes";
            }
            else if (ForeCast == "rain")
            {
                one = "Pack raingear and wear waterproof shoes";
            }
            else if (ForeCast == "thunderstorms")
            {
                one = "Seek shelter and avoid hiking on exposed ridges";
            }
            else if (ForeCast == "sunny")
            {
                one = "Pack sunblock";
            }
            else if (ForeCast == "partly cloudy")
            {
                one = "Dress in layers";
            }
            if(High >75)
            {
                two = " and bring an extra gallon of water";
            }
            if(High-Low >20)
            {
                three = " and wear breathable layers";
            }
            if(Low < 20)
            {
                four = "  and be aware that exposure to frigid temperatures could be dangerous to your health";
            }
            return one + two + three + four;
        }

        public string GetDay()
        {
            if(FiveDayForecastValue == 1)
            {
                return "Today";
            }
            else if (FiveDayForecastValue == 2)
            {
                return DateTime.Today.AddDays(1.00).DayOfWeek.ToString();
            }
            else if(FiveDayForecastValue == 3)
            {
                return DateTime.Today.AddDays(2.00).DayOfWeek.ToString();
            }
            else if (FiveDayForecastValue == 4)
            {
                return DateTime.Today.AddDays(3.00).DayOfWeek.ToString();
            }
            else 
            {
                return DateTime.Today.AddDays(4.00).DayOfWeek.ToString();
            }
        }       
    }
}   


