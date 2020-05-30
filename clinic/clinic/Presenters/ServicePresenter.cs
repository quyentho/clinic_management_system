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
        private readonly IServiceRepository _repository;
        private readonly IServiceView _view;
        public ServicePresenter(IServiceRepository serviceRepository, IServiceView view)
        {
            _repository = serviceRepository;
            _view = view;
        }
        public void Add()
        {

            var service = new clinic_service()
            {
                service_name = _view.TxtServiceName,
                price = long.Parse(_view.TxtPrice),
                is_active = true
            };
            _repository.InsertService(service);
       
        }
        public void Display(int idSelected)
        {
            var serviceFromDB = _repository.GetServiceById(idSelected);
            if (serviceFromDB != null)
            {
                _view.TxtServiceName = serviceFromDB.service_name;
                _view.TxtPrice = serviceFromDB.price.ToString();
            }
        }
        public void Delete(int idSelected)
        {

            var serviceFromDb = _repository.GetServiceById(idSelected);
            if (serviceFromDb != null)
            {
                _repository.DeleteService(idSelected);
            }
        }
        private clinic_service GetServiceFromView()
        {
            clinic_service clinic_Service = new clinic_service()
            {
                service_name = _view.TxtServiceName,
                price = long.Parse(_view.TxtPrice),
                is_active = true
            };
            return clinic_Service;
        }
        public void Edit(int idSelected)
        {
            var serviceEdited = GetServiceFromView();
            serviceEdited.id = idSelected;

            _repository.UpdateService(serviceEdited);
        }
        #region validating Method
        public bool ValidateName()
        {
            if (string.IsNullOrWhiteSpace(_view.TxtServiceName))
            {
                _view.ErrorMessage = "Nhập tên dịch vụ";
                return false;
            }
            _view.ErrorMessage = "";
            return true;
        }
        public bool ValidatePrice()
        {
            if (string.IsNullOrWhiteSpace(_view.TxtPrice))
            {
                _view.ErrorMessage = "Nhập giá";
                return false;
            }
            try
            {
                int quantity = int.Parse(_view.TxtPrice);
                if (quantity <= 0)
                {
                    _view.ErrorMessage = "giá phải lớn hơn 0";
                    return false;
                }
            }
            catch
            {
                _view.ErrorMessage = "Vui lòng nhập số";
                return false;
            }
            _view.ErrorMessage = "";
            return true;
        }       
        #endregion
    }
}

