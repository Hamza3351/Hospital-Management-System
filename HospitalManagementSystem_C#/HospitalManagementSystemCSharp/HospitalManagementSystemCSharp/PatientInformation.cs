using HospitalManagementSystemCSharp.Refactoring;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class PatientInformation : Form, IPatientRepository
    {
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        public PatientInformation()
        {
            InitializeComponent();
        }

        //Method to load patient data into the DataGridView
        public void LoadPatientData()
        {
            string query = "SELECT * FROM patient";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        //Method to search for a patient by ID and display details
        public void SearchPatientById(int patientId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT * FROM patient WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader["name"].ToString();
                    radioButton1.Checked = reader["gen"].ToString() == "Male";
                    radioButton2.Checked = reader["gen"].ToString() == "Female";
                    textBox3.Text = reader["age"].ToString();
                    textBox4.Text = reader["date"].ToString();
                    textBox5.Text = reader["cont"].ToString();
                    textBox6.Text = reader["addr"].ToString();
                    textBox7.Text = reader["disease"].ToString();
                    textBox8.Text = reader["status"].ToString();
                    textBox10.Text = reader["r_type"].ToString();
                    textBox9.Text = reader["building"].ToString();
                    textBox11.Text = reader["r_no"].ToString();
                    textBox12.Text = reader["price"].ToString();
                }
                else
                {
                    MessageBox.Show($"Sorry, patient with ID {patientId} is not available.");
                }
                con.Close();
            }
        }

        //Method to update patient details in the database
        public void UpdatePatient()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string gender = radioButton1.Checked ? "Male" : "Female";
                string updateQuery = "UPDATE patient SET name=@name, gen=@gen, age=@age, date=@date, cont=@cont, addr=@addr, disease=@disease, status=@status, r_type=@rType, building=@building, r_no=@rNo, price=@price WHERE id=@id";

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@gen", gender);
                cmd.Parameters.AddWithValue("@age", textBox3.Text);
                cmd.Parameters.AddWithValue("@date", textBox4.Text);
                cmd.Parameters.AddWithValue("@cont", textBox5.Text);
                cmd.Parameters.AddWithValue("@addr", textBox6.Text);
                cmd.Parameters.AddWithValue("@disease", textBox7.Text);
                cmd.Parameters.AddWithValue("@status", textBox8.Text);
                cmd.Parameters.AddWithValue("@rType", textBox10.Text);
                cmd.Parameters.AddWithValue("@building", textBox9.Text);
                cmd.Parameters.AddWithValue("@rNo", textBox11.Text);
                cmd.Parameters.AddWithValue("@price", textBox12.Text);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Patient {textBox2.Text}'s details updated successfully.");
                con.Close();
                // Refresh the patient list after update
                LoadPatientData(); 
            }
        }

        //Method to delete a patient record
        public void DeletePatient(int patientId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string deleteQuery = "DELETE FROM patient WHERE id = @id";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", patientId);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Patient record deleted successfully.");
                // Refresh the patient list after deletion
                LoadPatientData(); 
            }
        }

        //Event handler for form load
        private void PatientInformation_Load(object sender, EventArgs e)
        {
            // Load patient data on form load
            LoadPatientData(); 
        }

        //Event handler for search button click
        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int patientId))
            {
                SearchPatientById(patientId);
            }
            else
            {
                MessageBox.Show("Please enter a valid patient ID.");
            }
        }

        //Event handler for update button click
        private void Button2_Click(object sender, EventArgs e)
        {
            UpdatePatient();
        }

        //Event handler for delete button click
        private void Button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int patientId))
            {
                DeletePatient(patientId);
            }
            else
            {
                MessageBox.Show("Please enter a valid patient ID.");
            }
        }
    }
}
