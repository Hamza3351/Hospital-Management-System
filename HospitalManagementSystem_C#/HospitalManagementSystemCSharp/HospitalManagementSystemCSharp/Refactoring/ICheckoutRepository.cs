using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Checkout Interface Extraction
    public interface ICheckoutRepository
    {
        DataTable GetAllCheckouts();
        DataTable GetCheckoutById(int id);
    }
}

