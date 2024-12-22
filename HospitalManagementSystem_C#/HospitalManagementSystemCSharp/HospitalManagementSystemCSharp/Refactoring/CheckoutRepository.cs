using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp.Refactoring
{
    public class CheckoutRepository : ICheckoutRepository
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to get all checkouts from the database
        public DataTable GetAllCheckouts()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM checkout";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Method to get the checkout details according to ID
        public DataTable GetCheckoutById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM checkout WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
