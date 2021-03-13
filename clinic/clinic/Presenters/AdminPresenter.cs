using System.Collections.Generic;
using clinic.Views;
using clinic.Models;
using clinic.Models.Repositories;
using clinic.BusinessDomain.Medicine;
using clinic.Utilities;
using clinic.BusinessDomain.Service;
using clinic.BusinessDomain.Statistic;
using System;

namespace clinic.Presenters
{
    class AdminPresenter
    {
        private IAdminView _view;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBillRepository _billRepository;
        private readonly IStatisticRepository _statisticRepository;

        public AdminPresenter(IAdminView view,IMedicineRepository medicineRepository
            ,IStaffRepository staffRepository,IServiceRepository serviceRepository
            ,IBillRepository billRepository,
            IStatisticRepository statisticRepository
            )
        {
            _view = view;
            _medicineRepository = medicineRepository;
            _staffRepository = staffRepository;
            _serviceRepository = serviceRepository;
            _billRepository = billRepository;
            _statisticRepository = statisticRepository;
        }
        public void DisplayStaffs()
        {
            _view.AdminDataGridView.DataSource = null;
            _view.AdminDataGridView.DataSource = GetStaffsToDisplay();
        }
        public void DisplayMedicines()
        {
            _view.AdminDataGridView.DataSource = null;
            _view.AdminDataGridView.DataSource = GetMedicinesToDisplay();
        }
        public void DisplayServices()
        {
            _view.AdminDataGridView.DataSource = null;
            _view.AdminDataGridView.DataSource = GetServicesToDisplay();
        }
        private List<ServiceVM> GetServicesToDisplay()
        {
            var services = _serviceRepository.GetAll();
            List<ServiceVM> serviceVMs = new List<ServiceVM>();
            foreach (var service in services)
            {
                serviceVMs.Add(Transform.ServiceTransform(service));
            }

            return serviceVMs;
        }
        private List<StaffViewModel> GetStaffsToDisplay()
        {
            return _staffRepository.GetStaffList();
        }
        private List<AdminMedicineVM> GetMedicinesToDisplay()
        {
            var medicines = _medicineRepository.GetAll();
            List<AdminMedicineVM> medicineVMs = new List<AdminMedicineVM>();
            foreach (var medicine in medicines)
            {
                medicineVMs.Add(Transform.AdminMedicineTransform(medicine));
            }

            return medicineVMs;
        }
        public void SearchMedicines()
        {
            _view.AdminDataGridView.DataSource = _medicineRepository.GetMedicinesByName(_view.TxtTimKiem);
        }

        public void DisplayRevenue()
        {
            _view.AdminDataGridView.DataSource = null;
            var listRevenue = new List<RevenueViewModel>();

            if (_view.RbDate == true)
                listRevenue.Add(_billRepository.GetRevenueByDate(_view.DtpRevenue));
            else if (_view.RbMonth == true)
                   listRevenue.Add(_billRepository.GetRevenueByMonth(_view.DtpRevenue));
            else if (_view.RbYear == true)
                listRevenue.Add(_billRepository.GetRevenueByYear(_view.DtpRevenue));

            _view.AdminDataGridView.DataSource = listRevenue;
        }
        public void SearchStaffs()
        {
            _staffRepository.GetStaffsByName(_view.TxtTimKiem);
        }

        public void SearchServices()
        {
            _serviceRepository.GetServicesByName(_view.TxtTimKiem);
        }

        public void DisplayTestStatistic()
        {
            _view.AdminDataGridView.DataSource = null;

            List<ServiceStatistic> testStatistics = _statisticRepository.GetAllActive();
            List<TestVM> testVMs = new List<TestVM>();
            foreach (var item in testStatistics)
            {
                testVMs.Add(Transform.TestTransform(item));
            }

            _view.AdminDataGridView.DataSource = testVMs;
            
        }

        public void InitializeNewRecord(int serviceId, int medicineId)
        {
            _statisticRepository.InitializeNewRecord(serviceId, medicineId);
            
            DisplayTestStatistic();
        }
    }
}
