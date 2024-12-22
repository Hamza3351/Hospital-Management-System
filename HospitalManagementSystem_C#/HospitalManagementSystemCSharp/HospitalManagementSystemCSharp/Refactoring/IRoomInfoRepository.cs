using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemCSharp.Refactoring
{
    //Room Info Interface Extraction
    public interface IRoomInfoRepository
    {
        DataTable GetAllRooms(); 
        void AddRoom(string building, string roomType, string roomNo, int bedCount, decimal price, string status); 
    }

}
