using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Views;
using clinic.Models;
using clinic.Models.Repositories;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace clinic.Presenters
{
    class AdminPresenter
    {
        private IAdminView _view;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBillRepository _billRepository;
        public AdminPresenter(IAdminView view,IMedicineRepository medicineRepository
            ,IStaffRepository staffRepository,IServiceRepository serviceRepository
            ,IBillRepository billRepository)
        {
            _view = view;
            _medicineRepository = medicineRepository;
            _staffRepository = staffRepository;
            _serviceRepository = serviceRepository;
            _billRepository = billRepository;
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
        private List<clinic_service> GetServicesToDisplay()
        {
            return _serviceRepository.GetServiceList();
        }
        private List<StaffViewModel> GetStaffsToDisplay()
        {
            return _staffRepository.GetStaffList();
        }
        private List<medicine> GetMedicinesToDisplay()
        {
            return _medicineRepository.GetMedicineList();
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
    }
}
