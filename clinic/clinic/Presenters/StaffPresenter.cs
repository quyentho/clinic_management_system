using clinic.Models.Repositories;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
using System.Globalization;

namespace clinic.Presenters
{
    class StaffPresenter : Presenter
    {
        private IStaffView _view;
        private readonly IStaffRepository _repository;
        private readonly IPermissionRepository _permissionRepository;
        public StaffPresenter(IStaffRepository staffRepository,
            IPermissionRepository permissionRepository,IStaffView staffView)
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
                date_of_birth = DateTime.ParseExact(_view.TxtDoB, dateTimeFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.None),
                phone_number = _view.TxtPhone,
                salary = Int64.Parse(_view.TxtSalary),
                permission_id = _view.CbPermission_id,
                is_still_working = true
            };
            _repository.InsertStaff(staff);
        }
        private void SetPermissionComboBox()
        {
            _view.CbPermission.DataSource = _permissionRepository.GetPermissionList();
            _view.CbPermission.DisplayMember = "position_name";
            _view.CbPermission.ValueMember = "id";
            _view.CbPermission.Invalidate();
        }
        public void Display(int idSelected)
        {
            var staffToDisplay = _repository.GetStaffById(idSelected);
            if (staffToDisplay != null)
            {
                //Display from db to view
                _view.TxtStaffName = staffToDisplay.FullName;
                _view.TxtDoB = staffToDisplay.DateOfBirth.ToString("dd/MM/yyyy");
                _view.TxtPhone = staffToDisplay.PhoneNumber;
                _view.TxtSalary = staffToDisplay.Salary.ToString();
                _view.CbPermission.Text = staffToDisplay.PositionName;
            }
        }
        public void Delete(int idSelected)
        {
            _repository.DeleteStaff(idSelected);
        }
        public void Edit(int idSelected)
        {

            var staffFromDB = _repository.GetStaffById(idSelected);
            var staffUpdated = new staff() { is_still_working = true };
                
            if (staffFromDB != null)
            {
                staffUpdated.id = idSelected;
                staffUpdated.full_name = _view.TxtStaffName;
                staffUpdated.date_of_birth = DateTime.ParseExact(_view.TxtDoB, dateTimeFormats
                                            ,CultureInfo.InvariantCulture, DateTimeStyles.None);
                staffUpdated.phone_number = _view.TxtPhone;
                staffUpdated.salary = long.Parse(_view.TxtSalary);
                staffUpdated.permission_id = _view.CbPermission_id;

                _repository.UpdateStaff(staffUpdated);
            }
        }
    }
}
