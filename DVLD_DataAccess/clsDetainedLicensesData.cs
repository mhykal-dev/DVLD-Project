using AccessSettings_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetainedLicenses_DataAccess
{
    public class clsDetainedLicensesData
    {
        public static bool GetDetainedLicenseInFoByDetainedID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref int FineFees, ref int CreatedByUserID, ref int IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound              = true;
                    LicenseID            = Convert.ToInt32(reader["LicenseID"]);
                    DetainDate           = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees             = Convert.ToInt32(reader["FineFees"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased           = Convert.ToInt32(reader["IsReleased"]);
                    ReleaseDate          = Convert.ToDateTime(reader["ReleaseDate"]);
                    ReleasedByUserID     = Convert.ToInt32(reader["ReleasedByUserID"]);
                    ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);

                }

                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetDetainedLicenseInFoByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate,
            ref int FineFees, ref int CreatedByUserID, ref int IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound              = true;
                    DetainID             = Convert.ToInt32(reader["DetainID"]);
                    DetainDate           = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees             = Convert.ToInt32(reader["FineFees"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased           = Convert.ToInt32(reader["IsReleased"]);
                    ReleaseDate          = Convert.ToDateTime(reader["ReleaseDate"]);
                    ReleasedByUserID     = Convert.ToInt32(reader["ReleasedByUserID"]);
                    ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);

                }

                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetDetainedLicenseInFoByDetainDate(ref int DetainID, ref int LicenseID, DateTime DetainDate,
            ref int FineFees, ref int CreatedByUserID, ref int IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainDate = @DetainDate";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound              = true;
                    DetainID             = Convert.ToInt32(reader["DetainID"]);
                    LicenseID            = Convert.ToInt32(reader["LicenseID"]);
                    FineFees             = Convert.ToInt32(reader["FineFees"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased           = Convert.ToInt32(reader["IsReleased"]);
                    ReleaseDate          = Convert.ToDateTime(reader["ReleaseDate"]);
                    ReleasedByUserID     = Convert.ToInt32(reader["ReleasedByUserID"]);
                    ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    CreatedByUserID      = Convert.ToInt32(reader["CreatedByUserID"]);

                }

                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewLicense(int LicenseID, DateTime DetainDate,
            int FineFees, int CreatedByUserID, int IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, 
                                ReleasedByUserID, ReleaseApplicationID, IssueReason, CreatedByUserID)
                             VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, 
                                     @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID, @IssueReason ,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            finally
            {
                connection.Close();
            }

            return DetainID;
        }

        public static bool UpdateLicense(int DetainID, int LicenseID, DateTime DetainDate,
            int FineFees, int CreatedByUserID, int IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  DetainedLicenses  
                            set LicenseID = @LicenseID,
                                DetainDate = @DetainDate,
                                FineFees = @FineFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsReleased = @IsReleased,
                                ReleaseDate = @ReleaseDate,
                                ReleasedByUserID = @ReleasedByUserID,
                                ReleaseApplicationID = @ReleaseApplicationID,
                                IssueReason = @IssueReason, 
                                CreatedByUserID = @CreatedByUserID
                                where DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetAllDetainedLicensesForThisDetainDate(DateTime DetainDate)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainDate = @DetainDate";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
