using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
using clinic.Views;
namespace clinic.Presenters
{
    class ServicePresenter
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceView _serviceView;
        public ServicePresenter(IServiceRepository serviceRepository, IServiceView view)
        {
            _serviceRepository = serviceRepository;
            _serviceView = view;
        }
        public async Task<string> Add()
        {
            string notification = "";
            try
            {
                var service = new clinic_service()
                {
                    service_name = _serviceView.TxtServiceName,                   
                    price = decimal.Parse(_serviceView.TxtPrice)
                };
                _serviceRepository.InsertService(service);
                await _serviceRepository.Save();

            }
            catch (Exception ex)
            {
                notification = ex.ToString();
            }
            return notification;
        }
        public void Display(int idSelected)
        {
            var serviceFromDB = _serviceRepository.GetServiceById(idSelected);
            if (serviceFromDB != null)
            {
                //Display from db to view
                _serviceView.TxtServiceName = serviceFromDB.service_name;
                
                _serviceView.TxtPrice = serviceFromDB.price.ToString();
            }

        }
        public async Task<string> Delete(int idSelected)
        {
            string notification = "";
            try
            {
                var serviceFromDb = _serviceRepository.GetServiceById(idSelected);
                if (serviceFromDb != null)
                {
                    _serviceRepository.DeleteService(serviceFromDb);
                    await _serviceRepository.Save();
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
            var serviceFromDB = _serviceRepository.GetServiceById(idSelected);
            if (serviceFromDB != null)
            {
                try
                {
                    serviceFromDB.service_name = _serviceView.TxtServiceName;
                   
                    serviceFromDB.price = decimal.Parse(_serviceView.TxtPrice);
                    await _serviceRepository.Save();



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
            if (string.IsNullOrWhiteSpace(_serviceView.TxtServiceName))
            {
                _serviceView.ErrorMessage = "Nhập tên thuốc";
                isValid = false;
            }
            else
            {
                _serviceView.ErrorMessage = "";

            }
            return isValid;
        }
        public bool ValidatePrice()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_serviceView.TxtPrice))
            {
                _serviceView.ErrorMessage = "Nhập giá";
                isValid = false;
            }
            else
            {
                _serviceView.ErrorMessage = "";
                try
                {
                    double price = double.Parse(_serviceView.TxtPrice);
                    if (price >= 0)
                    {
                        _serviceView.ErrorMessage = "";
                    }
                    else
                    {
                        _serviceView.ErrorMessage = "Giá phải lớn hơn 0";
                        isValid = false;
                    }
                }
                catch
                {
                    _serviceView.ErrorMessage = "Vui lòng nhập đúng số";
                    isValid = false;
                }
            }
            return isValid;
        }
        public bool ValidateAllInput()
        {
            bool isValidName = ValidateName();
            bool isValidPrice = ValidatePrice();

            if (isValidName && isValidPrice)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
