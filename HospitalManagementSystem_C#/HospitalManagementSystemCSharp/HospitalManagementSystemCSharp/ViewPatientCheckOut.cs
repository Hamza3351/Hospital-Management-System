using HospitalManagementSystemCSharp.Refactoring;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class ViewPatientCheckOut : Form
    {
        private readonly ICheckoutRepository _checkoutRepository;

        //Constructor to initialize the form
        public ViewPatientCheckOut(ICheckoutRepository checkoutRepository)
        {
            InitializeComponent();
            _checkoutRepository = checkoutRepository;
        }

        //This method loads the checkout data into the DataGridView on form load
        private void ViewPatientCheckOut_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _checkoutRepository.GetAllCheckouts();
        }

        //This is a search button to search checkout of a patient by ID
        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                dataGridView1.DataSource = _checkoutRepository.GetCheckoutById(id);
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.");
            }
        }
    }
}
