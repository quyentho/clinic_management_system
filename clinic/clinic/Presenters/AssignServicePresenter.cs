using clinic.Models;
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
        public AssignServicePresenter(IServiceRepository repository,IBillRepository billRepository,IAssignServiceView view)
        {
            _serviceRepository = repository;
            _billRepository = billRepository;
            _view = view;

            DisplayServiceDataGridView();
        }

        private void DisplayServiceDataGridView()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
            HashSet<int> serviceAssignedIds = new HashSet<int>(bill.clinic_service.Select(s => s.id));

            List<clinic_service> serviceToDisplay = _serviceRepository.GetServiceList()
                .Where(s => !serviceAssignedIds.Contains(s.id)).ToList(); // Not display service  
                                                                          // already assinged                    
            _view.DgvServiceDataSource = serviceToDisplay;
        }
        public void AssignService()
        {
            var serviceSelected = _serviceRepository.GetServiceById(_view.IdServiceSelected);

            if (!(_view.ListServiceSelected.Contains(serviceSelected)))
            {
                _view.ListServiceSelected.Add(serviceSelected);
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
            _view.ListServiceSelected.RemoveAt(_view.IndexRemove);
        }

        public void AddServiceAssignedToBillIfExists()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
            if(_view.ListServiceSelected.Count > 0)
            {
                foreach(clinic_service serviceSelected in _view.ListServiceSelected)
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
