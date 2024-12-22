using HospitalManagementSystemCSharp.Refactoring;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class StaffInformation : Form
    {
        private readonly IStaffRepository _staffRepository;

        //Constructor to initialize the form
        public StaffInformation(IStaffRepository staffRepository)
        {
            InitializeComponent();
            _staffRepository = staffRepository;
        }

        //This method loads the staff data into the DataGridView on form load
        private void StaffInformation_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _staffRepository.GetAllStaff();
        }

        //This button will trigger the add staff method to insert the details of a new staff member
        private void Button1_Click(object sender, EventArgs e)
        {
            string gender = radioButton1.Checked ? "Male" : "Female";
            try
            {
                _staffRepository.AddStaff(textBox2.Text, gender, textBox4.Text, Convert.ToDecimal(textBox5.Text), textBox6.Text, textBox7.Text);
                MessageBox.Show("Staff Information Saved Successfully..");
                ClearFields();
                dataGridView1.DataSource = _staffRepository.GetAllStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //This is a search button to search staff by ID
        private void Button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                DataRow staff = _staffRepository.GetStaffById(id);
                if (staff != null)
                {
                    textBox2.Text = staff["name"].ToString();
                    radioButton1.Checked = staff["gender"].ToString() == "Male";
                    radioButton2.Checked = !radioButton1.Checked;
                    textBox4.Text = staff["position"].ToString();
                    textBox5.Text = staff["salary"].ToString();
                    textBox6.Text = staff["contact"].ToString();
                    textBox7.Text = staff["address"].ToString();
                }
                else
                {
                    MessageBox.Show($"Staff with ID {id} not found.");
                    textBox1.Clear();
                }
            }
        }

        //This button triggers the update query to update staff info
        private void Button4_Click(object sender, EventArgs e)
        {
            string gender = radioButton1.Checked ? "Male" : "Female";
            try
            {
                _staffRepository.UpdateStaff(Convert.ToInt32(textBox1.Text), textBox2.Text, gender, textBox4.Text, Convert.ToDecimal(textBox5.Text), textBox6.Text, textBox7.Text);
                MessageBox.Show("Staff details updated successfully.");
                ClearFields();
                dataGridView1.DataSource = _staffRepository.GetAllStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Clear button
        private void Button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Method to clear the input fields
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
