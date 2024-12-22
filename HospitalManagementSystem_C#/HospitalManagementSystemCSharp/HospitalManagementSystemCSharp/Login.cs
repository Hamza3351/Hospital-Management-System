using HospitalManagementSystemCSharp.Refactoring;
using System;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class Login : Form
    {
        //Call the interface
        private readonly ILoginBehavior _loginBehavior;

        public Login()
        {
            InitializeComponent();
            _loginBehavior = new LoginBehavior(this);
        }

        //Handle login method
        private void Button1_Click(object sender, EventArgs e)
        {
            _loginBehavior.HandleLogin();
        }

        //Handle clear fields method
        private void Button2_Click(object sender, EventArgs e)
        {
            _loginBehavior.ClearInputFields();
        }

        //Encapsulated fields for textBox1 and textBox2
        public string Username => textBox1.Text;
        public string Password => textBox2.Text;

        //Method to clear text fields
        public void ClearInputFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //Method to show a success message
        public void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message);
        }

        //Method to show an error message
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        //Method to navigate to Home form
        public void OpenHomePage()
        {
            this.Visible = false;
            Home homePage = new Home();
            homePage.ShowDialog();
        }
    }
}
