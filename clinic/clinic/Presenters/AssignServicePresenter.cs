using clinic.BusinessDomain.Service;
using clinic.Models;
using clinic.Utilities;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;


namespace clinic.Presenters
{
    public class AssignServicePresenter
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IBillRepository _billRepository;
        private readonly IAssignServiceView _view;

        private List<clinic_service> _temporarySelectedServices = new List<clinic_service>();
        public AssignServicePresenter(IServiceRepository repository,
            IBillRepository billRepository,
            IAssignServiceView view)
        {
            _serviceRepository = repository;
            _billRepository = billRepository;
            _view = view;

            DisplayServiceDataGridView();
        }

        public void DisplayServiceDataGridView()
        {
            var services = _serviceRepository.GetAll();
            var serviceVMs = GetServiceVMs(services);

            _view.DgvServiceDataSource = serviceVMs;
        }

        private List<ServiceVM> GetServiceVMs(List<clinic_service> services)
        {
            List<ServiceVM> serviceVMs = new List<ServiceVM>();
            foreach (var service in services)
            {
                serviceVMs.Add(Transform.ServiceTransform(service));
            }
            return serviceVMs;
        }

        public void AssignService()
        {
            var serviceSelected = _serviceRepository.GetServiceById(_view.IdServiceSelected);

            if (!(_temporarySelectedServices.Contains(serviceSelected)))
            {
                _temporarySelectedServices.Add(serviceSelected);
                DisplayServiceSelected(serviceSelected);
            }
        }

        private void DisplayServiceSelected(clinic_service serviceSelected)
        {
            _view.DgvServicesSelected.Rows.Add(serviceSelected.service_name, serviceSelected.price);
        }

        public void RemoveServiceAssigned()
        {
            _view.DgvServicesSelected.Rows.RemoveAt(_view.IndexRemove);
            _temporarySelectedServices.RemoveAt(_view.IndexRemove);
        }
        public void LoadExistingServices(int patientId)
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(patientId);

            _temporarySelectedServices = bill.clinic_service.ToList();

            foreach (var service in _temporarySelectedServices)
            {
                DisplayServiceSelected(service);
            }
        }
        public void AddServicesToBill()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
            
            // clear in case of update.
            _billRepository.ClearServicesInBill(bill);

            if (_temporarySelectedServices.Count > 0)
            {
                foreach (clinic_service serviceSelected in _temporarySelectedServices)
                {
                    try
                    {
                        _billRepository.AddServiceToBill(bill.id, serviceSelected);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        _view.ErrMessage = ex.Message;
                    }
                }
            }
            _billRepository.CalculateTotalMoneyInBill(bill.id);
        }
    }
}
