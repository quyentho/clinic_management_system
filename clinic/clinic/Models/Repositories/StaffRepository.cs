using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly clinicEntities _clinicEntities;
        private readonly IPermissionRepository _permission;
       // private IList<staff> _staffs;
        //private IList<string> _permissionOfStaffs;
        private IList<StaffViewModel> _staffViewModels;
        
        public StaffRepository(clinicEntities entities, IPermissionRepository permission)
        {
            _clinicEntities = entities;
            _permission = permission;
            _staffViewModels = GetStaffsFromDatabase();

       //     GetPermissionForEachStaff();
        }


      //  HACK: Comment this function for running
        public void DeleteStaff(staff staff)
        {
            //_staffViewModels.Remove(staff);
            //if (!_clinicEntities.staffs.Local.Contains(staff))
            //{
            //    _clinicEntities.staffs.Attach(staff);
            //}
            //_clinicEntities.staffs.Remove(staff);
            throw new NotImplementedException();
        }

        public StaffViewModel GetStaffById(int id)
        {
            var staff = _staffViewModels.Where(s => s.Id == id).FirstOrDefault();
            return staff;
        }

        //HACK: comment this function for runnning, fix later
        public IList<staff> GetStaffsByName(string staffName)
        {
            //var staffs = _staffs.Where(m => m.full_name.Contains(staffName)).ToList();
            //return staffs;
            throw new NotImplementedException();
        }

        private IList<StaffViewModel> GetStaffsFromDatabase()
        {
            return _clinicEntities.staffs
                .Include(s => s.permission)
                .Where(s => s.is_still_working == true).AsNoTracking()
                .Select(s => new StaffViewModel(){
                    Id = s.id,
                    FullName = s.full_name,
                    DateOfBirth = s.date_of_birdth,
                    PhoneNumber = s.phone_number,
                    Salary = s.salary,
                    PositionName = s.permission.position_name
                })
                .ToList();
        }
        public IList<StaffViewModel> GetStaffList()
        {
            return _staffViewModels;
        }

        //HACK: comment this function for runnning, fix later
        public void InsertStaff(staff staff)
        {
            //_staffViewModels.Add(staff);
            //_clinicEntities.staffs.Add(staff);
            throw new NotImplementedException();
        }

        public void Save()
        {
            _clinicEntities.SaveChanges();
        }

        //HACK: comment this function for runnning, fix later
        public void UpdateStaff(staff staff)
        {
            //var staffFromList = _staffs.FirstOrDefault(m => m.id == staff.id);

            //staffFromList = staff;

            //_clinicEntities.Set<staff>().AddOrUpdate(staff); //update staff in database
            throw new NotImplementedException();
        }
    }
}
