using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Patient Checkout interface extraction
    public interface IPatientCheckOut
    {
        void LoadPatientDetails(int patientId);
        void SavePatientCheckout();
        void ClearForm();
    }

}
