using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public interface IStaffRepository
    {
        IList<StaffViewModel> GetStaffList();
        IList<staff> GetStaffsByName(string name);
        StaffViewModel GetStaffById(int id);
        void InsertStaff(staff staff);
        void DeleteStaff(staff staff);
        void UpdateStaff(staff staff);
        void Save();
    }
}
