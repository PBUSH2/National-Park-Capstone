using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString;
        private const string SQL_InsertSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        private const string SQL_FindTopPark = "  SELECT top 1 parkName from park inner join survey_result on park.parkCode = survey_result.parkCode group by survey_result.parkCode order by count(*) desc;";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_InsertSurvey, conn);

                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        //public string FindTopPark()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand(SQL_FindTopPark, conn);
        //            SqlDataReader = cmd.ExecuteReader();

        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
    }
}
