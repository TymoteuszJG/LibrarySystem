using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Repositories
{
    public interface IStaffRepository
    {
        Staff AddStaff(Staff staff);
        List<Staff> GetStaff();
        int GetStaffId(string login, string password);

  }
}
