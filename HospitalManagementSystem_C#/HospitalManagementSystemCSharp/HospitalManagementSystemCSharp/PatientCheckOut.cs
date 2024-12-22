using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HospitalManagementSystemCSharp.Refactoring;

namespace HospitalManagementSystemCSharp
{
    public partial class PatientCheckOut : Form, IPatientCheckOut
    {
        private readonly PatientCheckOutRepository _repository = new PatientCheckOutRepository();

        public PatientCheckOut()
        {
            InitializeComponent();
        }

        //Method to load patient details
        public void LoadPatientDetails(int patientId)
        {
            _repository.LoadPatientDetails(patientId, out string name, out string gen, out string age, out string contact, out string addr, out string disease);

            if (!string.IsNullOrEmpty(name))
            {
                textBox2.Text = name;
                radioButton1.Checked = gen == "Male";
                radioButton2.Checked = gen == "Female";
                textBox3.Text = age;
                textBox5.Text = contact;
                textBox6.Text = addr;
                textBox7.Text = disease;
            }
            else
            {
                MessageBox.Show($"Sorry, patient with ID {patientId} is not available.");
                textBox1.Clear();
            }
        }

        //Method to save patient checkout information
        public void SavePatientCheckout()
        {
            string gender = radioButton1.Checked ? "Male" : "Female";
            _repository.SavePatientCheckout(textBox2.Text, gender, textBox3.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, textBox14.Text, textBox13.Text, textBox15.Text);

            MessageBox.Show("Patient Checkout Information Saved Successfully.");
            ClearForm();
        }

        //Method to clear the form fields
        public void ClearForm()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        //Event handler for patient ID text box changes
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int patientId))
            {
                LoadPatientDetails(patientId);
            }
            else
            {
                MessageBox.Show("Please enter a valid patient ID.");
            }
        }

        //Event handler for save button click
        private void Button1_Click(object sender, EventArgs e)
        {
            SavePatientCheckout();
        }

        //Event handler for clear button click
        private void Button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }

}
