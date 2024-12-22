using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Interface extraction for login behavior
    public interface ILoginBehavior
    {
        void HandleLogin();
        void ClearInputFields();
    }
}

