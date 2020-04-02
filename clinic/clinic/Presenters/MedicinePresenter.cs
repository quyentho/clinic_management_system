using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models.Repositories;

namespace clinic.Presenters
{
    class MedicinePresenter
    {
        private IMedicineView _medicineView;
        private readonly IMedicineRepository _medicineRepository;
        public MedicinePresenter(IMedicineRepository medicineRepository, IMedicineView medicineView)
        {
            _medicineView = medicineView;
            _medicineRepository = medicineRepository;
        }
        //public void SetEventArgs(Object obj)
        //{

        //    _medicineView.MyEventArgs = new Models.Bussiness_Logics.UpdateDataGridViewEventArgs();
        //    _medicineView.MyEventArgs.Value = obj;
        //}
        public async Task<string> AddMedicine()
        {
            string notification = "";
            try
            {
                var medicine = new medicine()
                {
                    medicine_name = _medicineView.TxtTenThuoc,
                    quantity = Convert.ToInt32(_medicineView.TxtSoLuong),
                    unit = _medicineView.TxtDonVi,
                    price_per_unit = decimal.Parse(_medicineView.TxtGia)
                };
                _medicineRepository.InsertMedicine(medicine);
                await _medicineRepository.Save();

            }
            catch (Exception ex)
            {
                notification = ex.ToString();
            }
            return notification;
        }
        public void DisplayMedicine(int idSelected)
        {
            var medicineFromDB = _medicineRepository.GetMedicineById(idSelected);
            if (medicineFromDB != null)
            {
               //Display from db to view
                _medicineView.TxtTenThuoc = medicineFromDB.medicine_name;
                _medicineView.TxtSoLuong = medicineFromDB.quantity.ToString();
                _medicineView.TxtDonVi = medicineFromDB.unit;
                _medicineView.TxtGia = medicineFromDB.price_per_unit.ToString();
            }

        }
        public async Task<string> DeleteMedicine(int idSelected)
        {
            string notification = "";
            try
            {
                var medicineFromDb = _medicineRepository.GetMedicineById(idSelected);
                if (medicineFromDb != null)
                {
                    _medicineRepository.DeleteMedicine(medicineFromDb);
                   await _medicineRepository.Save();
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
        public async Task<string> EditMedicine(int idSelected)
        {
            string notification = "";
            var medicineFromDB = _medicineRepository.GetMedicineById(idSelected);
            if (medicineFromDB != null)
            {
                try
                {
                    medicineFromDB.medicine_name = _medicineView.TxtTenThuoc;
                    medicineFromDB.quantity = int.Parse(_medicineView.TxtSoLuong);
                    medicineFromDB.unit = _medicineView.TxtDonVi;
                    medicineFromDB.price_per_unit = decimal.Parse(_medicineView.TxtGia);
                    await _medicineRepository.Save();

              

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
            if (string.IsNullOrWhiteSpace(_medicineView.TxtTenThuoc))
            {
                _medicineView.ErrorMessage = "Nhập tên thuốc";
                isValid = false;
            }
            else
            {
                _medicineView.ErrorMessage = "";

            }
            return isValid;
        }
        public bool ValidateQuantity()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_medicineView.TxtSoLuong))
            {
                _medicineView.ErrorMessage = "Nhập số lượng";
                isValid = false;
            }
            else
            {
                _medicineView.ErrorMessage = "";
                try
                {
                    int number = int.Parse(_medicineView.TxtSoLuong);
                    if (number >= 0)
                    {
                        _medicineView.ErrorMessage = "";
                    }
                    else
                    {
                        _medicineView.ErrorMessage = "Số lượng phải lớn hơn 0";
                        isValid = false;
                    }
                }
                catch
                {
                    _medicineView.ErrorMessage = "Vui lòng nhập đúng số";
                    isValid = false;
                }
            }
            return isValid;
        }

        public bool ValidateUnit()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_medicineView.TxtDonVi))
            {
                _medicineView.ErrorMessage = "Nhập đơn vị";
                isValid = false;
            }
            else
            {
                _medicineView.ErrorMessage = "";
            }
            return isValid;
        }
        public bool ValidatePrice()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_medicineView.TxtGia))
            {
                _medicineView.ErrorMessage = "Nhập giá";
                isValid = false;
            }
            else
            {
                _medicineView.ErrorMessage = "";
                try
                {
                    double price = double.Parse(_medicineView.TxtGia);
                    if (price >= 0)
                    {
                        _medicineView.ErrorMessage = "";
                    }
                    else
                    {
                        _medicineView.ErrorMessage = "Giá phải lớn hơn 0";
                        isValid = false;
                    }
                }
                catch
                {
                    _medicineView.ErrorMessage = "Vui lòng nhập đúng số";
                    isValid = false;
                }
            }
            return isValid;
        }
        public bool ValidateAllInput()
        {
            bool isValidName = ValidateName();
            bool isValidPrice = ValidatePrice();
            bool isValidQuan = ValidateQuantity();
            bool isValidUnit = ValidateUnit();
            if (isValidName && isValidPrice && isValidQuan && isValidUnit)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
