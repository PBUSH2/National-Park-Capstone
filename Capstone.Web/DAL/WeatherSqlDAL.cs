using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString;
        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Forecast> GetForecast(string parkCode)
        {
            List<Forecast> forecastList = new List<Forecast>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from weather join park on park.parkCode = weather.parkCode where park.parkCode = @parkcode", conn);
                    cmd.Parameters.AddWithValue("@parkcode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Forecast forecast = new Forecast()
                        {
                            //ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            ForeCast = Convert.ToString(reader["forecast"]),
                            High = Convert.ToInt32(reader["high"]),
                            Low = Convert.ToInt32(reader["low"])
                        };
                        forecastList.Add(forecast);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return forecastList;
        }

       
    }
}