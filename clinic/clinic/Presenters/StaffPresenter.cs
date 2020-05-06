﻿using clinic.Models.Repositories;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
namespace clinic.Presenters
{
    class StaffPresenter : Presenter
    {
        private IStaffView _view;
        private readonly IStaffRepository _repository;
        private readonly IPermissionRepository _permissionRepository;
        public StaffPresenter(IStaffRepository staffRepository, IPermissionRepository permissionRepository,IStaffView staffView)
        {
            _view = staffView;
            _permissionRepository = permissionRepository;
            _repository = staffRepository;

            SetPermissionComboBox();
        }
        public void Add()
        {
            var staff = new staff()
            {
                full_name = _view.TxtStaffName,
                date_of_birdth = _view.TxtDoB,
                phone_number = _view.TxtPhone,
                salary = Int64.Parse(_view.TxtSalary),
                permission_id = _view.CbPermission_id,
                is_still_working = true
            };
            _repository.InsertStaff(staff);
            _repository.Save();
        }
        private void SetPermissionComboBox()
        {
            _view.CbPermission.DataSource = _permissionRepository.GetPermissionList();
            _view.CbPermission.DisplayMember = "position_name";
            _view.CbPermission.ValueMember = "id";
            _view.CbPermission.Invalidate();
        }
        //HACK: fix later
        public void Display(int idSelected)
        {
            //var staffFromDB = _repository.GetStaffById(idSelected);
            //if (staffFromDB != null)
            //{
            //    //Display from db to view
            //    _view.TxtStaffName = staffFromDB.full_name;
            //    _view.TxtDoB = staffFromDB.date_of_birdth;
            //    _view.TxtPhone = staffFromDB.phone_number;
            //    _view.TxtSalary = staffFromDB.salary.ToString();
            //    _view.CbPermission_id = staffFromDB.permission_id;
            //}

        }
        //HACK: fix later
        public void Delete(int idSelected)
        {
 
            //var staffFromDb = _repository.GetStaffById(idSelected);
            //if (staffFromDb != null)
            //{
            //    _repository.DeleteStaff(staffFromDb);
            //    _repository.Save();
            //}
         }
        //HACK: fix later
        public void Edit(int idSelected)
        {

            //var staffFromDB = _repository.GetStaffById(idSelected);
            //if (staffFromDB != null)
            //{
            //    staffFromDB.full_name = _view.TxtStaffName;
            //    staffFromDB.date_of_birdth = _view.TxtDoB;
            //    staffFromDB.phone_number = _view.TxtPhone;
            //    staffFromDB.salary = float.Parse(_view.TxtSalary);
            //    staffFromDB.permission_id = _view.CbPermission_id;
            //    _repository.Save();
            //}
        }
    }
}
