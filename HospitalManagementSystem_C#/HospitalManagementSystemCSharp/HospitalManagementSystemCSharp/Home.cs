using HospitalManagementSystemCSharp.Refactoring;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class Home : Form
    {
        //Getting the interfaces for each page to handle their functionality
        private readonly IPatientService _patientService;
        private readonly IRoomInfoRepository _roomInfoRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly ICheckoutRepository _checkoutRepository;

        //Initializng the dashboard
        public Home()
        {
            InitializeComponent();
            _patientService = new PatientService();
            _roomInfoRepository = new RoomInfoRepository();
            _staffRepository = new StaffRepository();
            _checkoutRepository = new CheckoutRepository();
        }

        //Goto the patient registration page
        private void PatientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientRegistration obj = new PatientRegistration(_patientService); 
            obj.ShowDialog();
        }

        //Goto the patient info page
        private void PatientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientInformation obj1 = new PatientInformation();
            obj1.ShowDialog();
        }

        //Goto the patient checkout page
        private void CheckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientCheckOut obj2 = new PatientCheckOut();
            obj2.ShowDialog();
        }

        //Goto the room info page
        private void RoomInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomInfo obj3 = new RoomInfo(_roomInfoRepository);
            obj3.ShowDialog();
        }

        //Goto the staff info page
        private void AddStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffInformation obj4 = new StaffInformation(_staffRepository);
            obj4.ShowDialog();
        }

        //Goto the view checkout page
        private void ViewCheckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewPatientCheckOut obj5 = new ViewPatientCheckOut(_checkoutRepository);
            obj5.ShowDialog();
        }
    }
}
