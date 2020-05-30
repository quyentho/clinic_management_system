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
        public AdminPresenter(IAdminView view,IMedicineRepository medicineRepository
            ,IStaffRepository staffRepository,IServiceRepository serviceRepository)
        {
            _view = view;
            _medicineRepository = medicineRepository;
            _staffRepository = staffRepository;
            _serviceRepository = serviceRepository;
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
    }
}
