using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp
{
    public class PatientService : IPatientService
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to get the next available patient ID
        public string GetNextPatientId()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT MAX(Id) FROM patient";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    return dr.Read() ? (Convert.ToInt32(dr[0].ToString()) + 1).ToString() : "1";
                }
            }
        }

        //Method to save patient information into the database
        public void SavePatientInformation(string gender, string name, string age, string date, string contact,
                                            string address, string disease, string status, string roomType,
                                            string building, string roomNo, string price)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string insertQuery = "INSERT INTO patient(name, gen, age, date, cont, addr, disease, status, r_type, building, r_no, price) " +
                                     "VALUES(@name, @gen, @age, @date, @cont, @addr, @disease, @status, @r_type, @building, @r_no, @price)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gen", gender);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@cont", contact);
                    cmd.Parameters.AddWithValue("@addr", address);
                    cmd.Parameters.AddWithValue("@disease", disease);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@r_type", roomType);
                    cmd.Parameters.AddWithValue("@building", building);
                    cmd.Parameters.AddWithValue("@r_no", roomNo);
                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

