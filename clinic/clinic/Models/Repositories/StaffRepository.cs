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
        private List<StaffViewModel> _staffViewModels;
        private readonly IPermissionRepository _permissionRepository;
        
        public StaffRepository(clinicEntities entities,IPermissionRepository permissionRepository)
        {
            _clinicEntities = entities;
            _permissionRepository = permissionRepository;
            _staffViewModels = GetStaffsFromDatabase();

       //     GetPermissionForEachStaff();
        }


      //  HACK: Comment this function for running
        public void DeleteStaff(int id)
        {
            var staffFromDb = _clinicEntities.staffs.Find(id);
            if(staffFromDb != null)
            {
                _staffViewModels.Remove(GetStaffById(id));
                _clinicEntities.staffs.Remove(staffFromDb);
                Save();
            }
        }

        public StaffViewModel GetStaffById(int id)
        {
            var staff = _staffViewModels.Where(s => s.Id == id).FirstOrDefault();
            return staff;
        }

        //HACK: comment this function for runnning, fix later
        public List<staff> GetStaffsByName(string staffName)
        {
            //var staffs = _staffs.Where(m => m.full_name.Contains(staffName)).ToList();
            //return staffs;
            throw new NotImplementedException();
        }

        private List<StaffViewModel> GetStaffsFromDatabase()
        {
            return _clinicEntities.staffs
                .Where(s => s.is_still_working == true)
                .Include(s=>s.permission)
                .Select(s => new StaffViewModel(){
                    Id = s.id,
                    FullName = s.full_name,
                    DateOfBirth = s.date_of_birth,
                    PhoneNumber = s.phone_number,
                    Salary = s.salary,
                    PositionName = s.permission.position_name
                })
                .ToList();
        }
        public List<StaffViewModel> GetStaffList()
        {
            return _staffViewModels;
        }

        //HACK: comment this function for runnning, fix later
        public void InsertStaff(staff newStaff)
        {
            InsertToList(newStaff);
            _clinicEntities.staffs.Add(newStaff);
            Save();
           
        }
        private void InsertToList(staff newStaff)
        {
            var staffVM = ConvertStaffToStaffVM(newStaff);
            _staffViewModels.Add(staffVM);
        }
        private void Save()
        {
            _clinicEntities.SaveChanges();
        }

        //HACK: comment this function for runnning, fix later
        public void UpdateStaff(staff staffUpdated)
        {

            var staffFromDb = _clinicEntities.staffs.Find(staffUpdated.id);
            if (staffFromDb != null)
            {
                _clinicEntities.AddOrUpdateEntity<staff>(_clinicEntities, staffUpdated);
                Save();
                UpdateStaffInList(staffUpdated);
            }
        }
        private StaffViewModel ConvertStaffToStaffVM(staff staff)
        {
            var newStaffVM = new StaffViewModel()
            {
                DateOfBirth = staff.date_of_birth,
                FullName = staff.full_name,
                Id = staff.id,
                PhoneNumber = staff.phone_number,
                Salary = staff.salary,
                PositionName = _permissionRepository.GetPermissionList()
                              .FirstOrDefault(p => p.id == staff.permission_id).position_name
            };
            return newStaffVM;
        }
        private void UpdateStaffInList(staff staffUpdated)
        {
            int index = _staffViewModels.FindIndex(s => s.Id == staffUpdated.id);
            var staffVM = ConvertStaffToStaffVM(staffUpdated);
            _staffViewModels[index] = staffVM;
        }
    }
}
