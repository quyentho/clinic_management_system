using clinic.Models.Repositories;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
namespace clinic.Presenters
{
    class StaffPresenter
    {
        private IStaffView _staffView;
        private readonly IStaffRepository _staffRepository;
        public StaffPresenter(IStaffRepository staffRepository, IStaffView staffView)
        {
            _staffView = staffView;
            _staffRepository = staffRepository;
        }
        public async Task<string> Add()
        {
            string notification = "";
            try
            {
                var staff = new staff()
                {
                    full_name = _staffView.TxtStaffName,
                    date_of_birdth =  _staffView.DtpDayOfBirth,
                    phone_number = _staffView.TxtPhone,
                    salary = float.Parse(_staffView.TxtSalary)
                };
                _staffRepository.InsertStaff(staff);
                await _staffRepository.Save();

            }
            catch (Exception ex)
            {
                notification = ex.ToString();
            }
            return notification;
        }
        public void Display(int idSelected)
        {
            var staffFromDB = _staffRepository.GetStaffById(idSelected);
            if (staffFromDB != null)
            {
                //Display from db to view
                _staffView.TxtStaffName = staffFromDB.full_name;
                _staffView.DtpDayOfBirth = staffFromDB.date_of_birdth.GetValueOrDefault();
                _staffView.TxtPhone = staffFromDB.phone_number;
                _staffView.TxtSalary = staffFromDB.salary.ToString();
            }

        }
        public async Task<string> Delete(int idSelected)
        {
            string notification = "";
            try
            {
                var staffFromDb = _staffRepository.GetStaffById(idSelected);
                if (staffFromDb != null)
                {
                    _staffRepository.DeleteStaff(staffFromDb);
                    await _staffRepository.Save();
                }
                else
                {
                    notification = "Thuốc không tồn tại";
                }
            }
            catch (Exception ex)
            {

                notification = ex.ToString();
            }
            return notification;


        }
        public async Task<string> Edit(int idSelected)
        {
            string notification = "";
            var staffFromDB = _staffRepository.GetStaffById(idSelected);
            if (staffFromDB != null)
            {
                try
                {
                    _staffView.TxtStaffName = staffFromDB.full_name;
                    _staffView.DtpDayOfBirth = staffFromDB.date_of_birdth.GetValueOrDefault();
                    _staffView.TxtPhone = staffFromDB.phone_number;
                    _staffView.TxtSalary = staffFromDB.salary.ToString();
                    await _staffRepository.Save();



                }
                catch (Exception ex)
                {
                    notification = ex.ToString();
                }
            }
            else
            {
                notification = "Thuốc không tồn tại";
            }
            return notification;
        }
        #region validating Method
        public bool ValidateName()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_staffView.TxtStaffName))
            {
                _staffView.ErrorMessage = "Nhập tên nhân viên";
                isValid = false;
            }
            else
            {
                _staffView.ErrorMessage = "";

            }
            return isValid;
        }      
        public bool ValidatePhone()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_staffView.TxtPhone))
            {
                _staffView.ErrorMessage = "Nhập SDT";
                isValid = false;
            }
            else
            {
                _staffView.ErrorMessage = "";
            }
            return isValid;
        }
        public bool ValidateSalary()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_staffView.TxtSalary))
            {
                _staffView.ErrorMessage = "Nhập lương";
                isValid = false;
            }
            else
            {
                _staffView.ErrorMessage = "";
                try
                {
                    double price = double.Parse(_staffView.TxtSalary);
                    if (price >= 0)
                    {
                        _staffView.ErrorMessage = "";
                    }
                    else
                    {
                        _staffView.ErrorMessage = "Lương phải lớn hơn 0";
                        isValid = false;
                    }
                }
                catch
                {
                    _staffView.ErrorMessage = "Vui lòng nhập đúng số";
                    isValid = false;
                }
            }
            return isValid;
        }
        public bool ValidateAllInput()
        {
            bool isValidName = ValidateName();
            bool isValidPhoneNumber = ValidatePhone();
            bool isValidSalary = ValidateSalary();

            if (isValidName && isValidPhoneNumber && isValidSalary)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
