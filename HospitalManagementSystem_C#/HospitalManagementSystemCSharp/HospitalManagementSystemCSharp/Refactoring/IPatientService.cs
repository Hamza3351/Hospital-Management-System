using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp
{
    //Patient Registration form interface extraction
    public interface IPatientService
    {
        string GetNextPatientId();
        void SavePatientInformation(string gender, string name, string age, string date, string contact,
                                     string address, string disease, string status, string roomType,
                                     string building, string roomNo, string price);
    }
}
