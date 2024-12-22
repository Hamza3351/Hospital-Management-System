using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class PatientRegistration : Form
    {
        private readonly IPatientService _patientService;

        //Constructor to initialize the form
        public PatientRegistration(IPatientService patientService)
        {
            _patientService = patientService;
            InitializeComponent();
        }

        //Event handler for the 'Save' button click
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = GetGender();
                _patientService.SavePatientInformation(gender, textBox2.Text, textBox3.Text, textBox4.Text,
                                                       textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text,
                                                       textBox10.Text, textBox9.Text, textBox11.Text, textBox12.Text);
                MessageBox.Show("Patient Information Saved Successfully..");
                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Event handler to load the patient registration form
        private void PatientRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = _patientService.GetNextPatientId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Event handler for the 'Clear' button click
        private void Button2_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        //Method to get the gender based on radio button selection
        private string GetGender()
        {
            return radioButton1.Checked ? "Male" : "Female";
        }

        //Method to clear all form fields
        private void ClearFormFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }
    }
}
