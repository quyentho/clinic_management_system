﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public interface IStaffRepository
    {
        List<StaffViewModel> GetStaffList();
        List<StaffViewModel> GetStaffsByName(string name);
        StaffViewModel GetStaffById(int id);
        void InsertStaff(staff staff);
        void DeleteStaff(int id);
        void UpdateStaff(staff staff);
        staff FindStaffFromDb(int id);
        void ChangeAccountPassword(int staffId, string newPassword);
    }
}
