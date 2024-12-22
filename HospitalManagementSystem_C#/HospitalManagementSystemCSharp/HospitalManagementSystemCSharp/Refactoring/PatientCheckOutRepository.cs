using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    public class PatientCheckOutRepository
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to load all patients and their details
        public void LoadPatientDetails(int patientId, out string name, out string gen, out string age, out string contact, out string addr, out string disease)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT name, gen, age, cont, addr, disease FROM patient WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["name"].ToString();
                    gen = reader["gen"].ToString();
                    age = reader["age"].ToString();
                    contact = reader["cont"].ToString();
                    addr = reader["addr"].ToString();
                    disease = reader["disease"].ToString();
                }
                else
                {
                    name = gen = age = contact = addr = disease = string.Empty;
                }
                con.Close();
            }
        }

        //Method to save patient checkout details
        public void SavePatientCheckout(string name, string gen, string age, string contact, string addr, string disease, string dateIn, string dateOut, string build, string roomNo, string roomType, string status, string medPrice, string total)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO checkout(name, gen, age, contact, addr, disease, date_in, date_out, build, r_no, r_type, status, med_price, total) " +
                               "VALUES(@name, @gen, @age, @contact, @addr, @disease, @date_in, @date_out, @build, @r_no, @r_type, @status, @med_price, @total)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gen", gen);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@addr", addr);
                cmd.Parameters.AddWithValue("@disease", disease);
                cmd.Parameters.AddWithValue("@date_in", dateIn);
                cmd.Parameters.AddWithValue("@date_out", dateOut);
                cmd.Parameters.AddWithValue("@build", build);
                cmd.Parameters.AddWithValue("@r_no", roomNo);
                cmd.Parameters.AddWithValue("@r_type", roomType);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@med_price", medPrice);
                cmd.Parameters.AddWithValue("@total", total);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

}
