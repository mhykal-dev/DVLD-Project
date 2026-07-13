using AccessSettings_DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PEOPLE_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInFoByID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // The record was found.
                            IsFound = true;
                            NationalNo = reader["NationalNo"] as string;
                            FirstName = reader["FirstName"] as string;
                            SecondName = reader["SecondName"] as string;

                            //ThirdName: allows null in database so we should handle null.
                            ThirdName = reader["ThirdName"] as string ?? "";

                            LastName = reader["LastName"] as string;
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gender = Convert.ToInt16(reader["Gender"]);
                            Address = reader["Address"] as string;
                            Phone = reader["Phone"] as string;

                            //Email: allows null in database so we should handle null.
                            Email = reader["Email"] as string ?? "";

                            NationalityCountryID = (int)reader["NationalityCountryID"];

                            //ImagePath: allows null in database so we should handle null
                            ImagePath = reader["ImagePath"] as string ?? "";
                        }
                    }
                }
            }
            return IsFound;
        }

        public static bool GetPersonInFoByNationalNo(ref int PersonID, string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // The record was found.
                            IsFound = true;

                            PersonID = (int)reader["PersonID"];
                            FirstName = reader["FirstName"] as string;
                            SecondName = reader["SecondName"] as string;

                            //ThirdName: allows null in database so we should handle null.
                            ThirdName = reader["ThirdName"] as string ?? "";

                            LastName = reader["LastName"] as string;
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Gender = Convert.ToInt16(reader["Gender"]);
                            Address = reader["Address"] as string;
                            Phone = reader["Phone"] as string;

                            //Email: allows null in database so we should handle null.
                            Email = reader["Email"] as string ?? "";

                            NationalityCountryID = (int)reader["NationalityCountryID"];

                            //ImagePath: allows null in database so we should handle null
                            ImagePath = reader["ImagePath"] as string ?? "";
                        }
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, 
                                Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                             VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, 
                                     @DateOfBirth, @Gender, @Address, @Phone ,@Email, @NationalityCountryID, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                    connection.Open();

                    object Result = command.ExecuteScalar();

                    if (Result != null)
                    {
                        PersonID = Convert.ToInt32(Result);
                    }
                }
            }
            return PersonID;
        }

        public static bool UpdatePerson(int ID, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            string query = @"Update  People  
                            set FirstName = @FirstName,                               
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                LastName = @LastName,
                                DateOfBirth = @DateOfBirth,
                                Gender = @Gender,
                                Address = @Address,
                                Phone = @Phone, 
                                Email = @Email, 
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath =@ImagePath
                                where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            string query =
              @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gender,  
				  CASE
                  WHEN People.Gender = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GenderCaption,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
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

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            string query = @"Delete People 
                                where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return (rowsAffected > 0);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }
                }
            }
            return isFound;
        }

        public static string GetPersonNameByID(int PersonID)
        {
            string FullName = "";
            string query = "SELECT FirstName, SecondName, ThirdName, LastName FROM People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string FirstName = reader["FirstName"] as string;
                            string SecondName = reader["SecondName"] as string;
                            string ThirdName = reader["ThirdName"] as string;
                            string LastName = reader["LastName"] as string;

                            FullName = string.Join(" ", new[] { FirstName, SecondName, ThirdName, LastName }.Where(S => !string.IsNullOrWhiteSpace(S)));
                        }
                    }
                }
            }
            return FullName;
        }
    }
}