using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Interface extraction for Patient Info
    public interface IPatientRepository
    {
        void LoadPatientData();
        void SearchPatientById(int patientId);
        void UpdatePatient();
        void DeletePatient(int patientId);
    }
}
