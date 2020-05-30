﻿using System;
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
        private List<StaffViewModel> _staffViewModelList;
        private IAccountRepository _accountRepository;
        private readonly IPermissionRepository _permissionRepository;
        
        public StaffRepository(clinicEntities entities, IPermissionRepository permissionRepository, IAccountRepository accountRepository)
        {
            _clinicEntities = entities;
            _permissionRepository = permissionRepository;
            _staffViewModelList = GetStaffsFromDatabase();
            _accountRepository = accountRepository;

        }


        public void DeleteStaff(int id)
        {
            var staffFromDb = _clinicEntities.staffs.Find(id);
            if(staffFromDb != null)
            {
                _staffViewModelList.Remove(GetStaffById(id));
                _clinicEntities.staffs.Remove(staffFromDb);
                Save();
            }
        }

        public StaffViewModel GetStaffById(int id)
        {
            var staff = _staffViewModelList.Where(s => s.Id == id).FirstOrDefault();
            return staff;
        }

        public List<staff> GetStaffsByName(string staffName)
        {
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
            return _staffViewModelList;
        }

        public void InsertStaff(staff newStaff)
       {
            if (_staffViewModelList.Any(s => s.PhoneNumber == newStaff.phone_number))
            {
                throw new ArgumentException();
            }
            InsertToList(newStaff);
            _clinicEntities.staffs.Add(newStaff);
            CreateNewAccount(newStaff);
            Save();
        }

        private void CreateNewAccount(staff newStaff)
        {
            var newAccount = new account()
            {
                is_active = true,
                pass = "1",
                permission_id = newStaff.permission_id,
                staff_id = _staffViewModelList.FindLastIndex(s => s.PhoneNumber == newStaff.phone_number) + 1,
                username = newStaff.phone_number
            };
            _accountRepository.Insert(newAccount);
        }

        private void InsertToList(staff newStaff)
        {
            var staffVM = ConvertStaffToStaffVM(newStaff);
            _staffViewModelList.Add(staffVM);
        }
        private void Save()
        {
            _clinicEntities.SaveChanges();
        }

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
                Id = staff.id == 0 ? _staffViewModelList.Count() + 1 : staff.id,
                PhoneNumber = staff.phone_number,
                Salary = staff.salary,
                PositionName = _permissionRepository.GetPermissionList()
                              .FirstOrDefault(p => p.id == staff.permission_id).position_name
            };
            return newStaffVM;
        }
        private void UpdateStaffInList(staff staffUpdated)
        {
            int index = _staffViewModelList.FindIndex(s => s.Id == staffUpdated.id);
            var staffVM = ConvertStaffToStaffVM(staffUpdated);
            _staffViewModelList[index] = staffVM;
        }
    }
}
