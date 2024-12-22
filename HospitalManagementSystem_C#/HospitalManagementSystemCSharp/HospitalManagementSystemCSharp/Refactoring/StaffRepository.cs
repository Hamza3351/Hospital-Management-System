using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp.Refactoring
{
    public class StaffRepository : IStaffRepository
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to get all staff members from the database
        public DataTable GetAllStaff()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM staff";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Method to add a staff member in the database
        public void AddStaff(string name, string gender, string position, decimal salary, string contact, string address)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO staff(name, gender, position, salary, contact, address) VALUES(@name, @gender, @position, @salary, @contact, @address)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
            }
        }

        //Method to get the required staff using their ID
        public DataRow GetStaffById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT name, gender, position, salary, contact, address FROM staff WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        //Method to update the staff member details
        public void UpdateStaff(int id, string name, string gender, string position, decimal salary, string contact, string address)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "UPDATE staff SET name = @name, gender = @gender, position = @position, salary = @salary, contact = @contact, address = @address WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
