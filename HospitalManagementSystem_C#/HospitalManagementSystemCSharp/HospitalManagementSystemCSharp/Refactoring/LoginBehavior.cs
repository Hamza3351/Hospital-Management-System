using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    public class LoginBehavior : ILoginBehavior
    {
        private readonly Login _loginForm;

        public LoginBehavior(Login loginForm)
        {
            _loginForm = loginForm;
        }

        //Method extraction for login handling logic
        public void HandleLogin()
        {
            if (IsValidLogin(_loginForm.Username, _loginForm.Password))
            {
                _loginForm.ShowSuccessMessage("Welcome Admin. You are logged in successfully.");
                _loginForm.OpenHomePage();
                _loginForm.ClearInputFields();
            }
            else
            {
                _loginForm.ShowErrorMessage("Invalid Username Or Password.");
            }
        }

        //Method to clear text fields
        public void ClearInputFields()
        {
            _loginForm.ClearInputFields();
        }

        //Method to validate login
        public bool IsValidLogin(string username, string password)
        {
            return username == "admin" && password == "pass";
        }
    }
}

