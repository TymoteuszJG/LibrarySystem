using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{

    public class StaffRepository : IStaffRepository
    {
        private readonly DatabaseContext _context;
        public StaffRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Staff AddStaff(Staff staff)
        {
             _context.Staff.Add(staff);
            _context.SaveChanges();
            return staff;
        }

        public List<Staff> GetStaff()
        {
            var result = _context.Staff.ToList();
            return result;
        }
    }
}
