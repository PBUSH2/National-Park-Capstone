using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.IO;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL: IParkDAL
    {
        private readonly string connectionString;
        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> listOfParks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park p = new Park()
                        {
                            Name = Convert.ToString(reader["parkName"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            State = Convert.ToString(reader["state"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                            EntryFee = Convert.ToInt32(reader["entryfee"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            Climate = Convert.ToString(reader["climate"]),
                            InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                            InspirationQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"])


                        };
                        listOfParks.Add(p);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOfParks;
        }
    }
}
                       

            

                        
