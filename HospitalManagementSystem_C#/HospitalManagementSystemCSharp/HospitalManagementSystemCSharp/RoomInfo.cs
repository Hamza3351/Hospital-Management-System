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
    public partial class RoomInfo : Form
    {
        private readonly IRoomInfoRepository _repository;

        //Constructor to initialize the form
        public RoomInfo(IRoomInfoRepository repository) 
        {
            InitializeComponent();
            _repository = repository;
        }

        //This method loads the room data into the DataGridView on form load
        private void RoomInfo_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable roomData = _repository.GetAllRooms(); 
                dataGridView1.DataSource = new BindingSource(roomData, null); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room data: " + ex.Message);
            }
        }

        //This method is triggered when the Save button is clicked to insert room info into the database
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate the input fields (optional step, you can add more validation logic as needed)
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                string building = textBox1.Text;
                string roomType = textBox2.Text;
                string roomNo = textBox3.Text;
                int bedCount = Convert.ToInt32(textBox4.Text);
                decimal price = Convert.ToDecimal(textBox5.Text); 
                string status = textBox6.Text;

                //Insert new room data into the database
                _repository.AddRoom(building, roomType, roomNo, bedCount, price, status);

                MessageBox.Show("Room information saved successfully.");

                //Clear input fields after successful save
                ClearFields();

                //Refresh the DataGridView to show the latest room data
                DataTable updatedRoomData = _repository.GetAllRooms();
                dataGridView1.DataSource = new BindingSource(updatedRoomData, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving room data: " + ex.Message);
            }
        }

        //This method is triggered when the Clear button is clicked to clear the input fields
        private void Button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Method to clear the input fields
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
