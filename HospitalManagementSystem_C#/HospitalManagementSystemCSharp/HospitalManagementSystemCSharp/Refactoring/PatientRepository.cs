using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp
{
    public class PatientRepository
    {
        //Connection string for the SQL database
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        //Method to get all patients from the database
        public DataTable GetAllPatients()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM patient";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt; 
            }
        }

        //Method to get a patient by their ID
        public DataRow GetPatientById(int patientId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM patient WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DataTable dt = reader.GetSchemaTable(); 
                    DataRow row = dt.NewRow(); 
                    object[] values = new object[reader.FieldCount]; 

                    reader.GetValues(values);
                    row.ItemArray = values; 

                    return row; 
                }
                else
                {
                    return null;
                }
            }
        }

        //Method to update patient information in the database
        public void UpdatePatient(int patientId, string name, string gender, string age, string date, string contact, string address, string disease, string status, string roomType, string building, string roomNumber, string price)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE patient SET name=@name, gen=@gender, age=@age, date=@date, cont=@contact, addr=@address, disease=@disease, status=@status, r_type=@roomType, building=@building, r_no=@roomNumber, price=@price WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@disease", disease);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@roomType", roomType);
                cmd.Parameters.AddWithValue("@building", building);
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                cmd.Parameters.AddWithValue("@price", price);

                con.Open();
                cmd.ExecuteNonQuery(); 
            }
        }

        //Method to delete a patient by their ID
        public void DeletePatient(int patientId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM patient WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientId);

                con.Open();
                cmd.ExecuteNonQuery(); 
            }
        }
    }
}
