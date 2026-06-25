using AccessSettings_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTypes_DataAccess
{
    public class clsApplicationsTypeData
    {
        public static bool GetApplicatinTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref int ApplicationFees)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            ApplicationTypeTitle = reader["ApplicationTypeTitle"] as string;
                            ApplicationFees = (int)reader["ApplicationFees"];

                        }

                        else
                        {
                            IsFound = false;
                        }
                    }
                }
            }
            return IsFound;
        }

        public static int GetApplicatinTypePrice(int ApplicationTypeID)
        {
            int ApplicationFees = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationFees = (int)reader["ApplicationFees"];

                            reader.Close();
                        }
                        else
                        {
                            ApplicationFees = -1;
                        }
                    }
                }
            }
            return ApplicationFees;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update  ApplicationTypes  
                            set ApplicationTypeTitle = @ApplicationTypeTitle,
                            ApplicationFees = @ApplicationFees                               
                            where ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllApplicatinsType()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        dt.Load(reader);
                    }

                }
            }
            return dt;

        }
    }
}
