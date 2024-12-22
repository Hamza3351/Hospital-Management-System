using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Staff Info Interface Extraction
    public interface IStaffRepository
    {
        DataTable GetAllStaff();
        void AddStaff(string name, string gender, string position, decimal salary, string contact, string address);
        DataRow GetStaffById(int id);
        void UpdateStaff(int id, string name, string gender, string position, decimal salary, string contact, string address);
    }
}

