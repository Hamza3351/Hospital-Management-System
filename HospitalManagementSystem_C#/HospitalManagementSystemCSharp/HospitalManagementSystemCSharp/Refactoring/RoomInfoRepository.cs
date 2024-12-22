using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    public class RoomInfoRepository : IRoomInfoRepository
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to get all room data from the database
        public DataTable GetAllRooms()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM room";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Method to insert new room data into the database
        public void AddRoom(string building, string roomType, string roomNo, int bedCount, decimal price, string status)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO room(building, r_type, r_no, no_bed, price, r_status) VALUES(@building, @r_type, @r_no, @no_bed, @price, @r_status)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@building", building);
                cmd.Parameters.AddWithValue("@r_type", roomType);
                cmd.Parameters.AddWithValue("@r_no", roomNo);
                cmd.Parameters.AddWithValue("@no_bed", bedCount);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@r_status", status);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
