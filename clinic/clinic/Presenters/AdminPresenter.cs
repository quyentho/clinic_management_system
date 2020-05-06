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
        public AdminPresenter(IAdminView view,IMedicineRepository medicineRepository,IStaffRepository staffRepository,IServiceRepository serviceRepository)
        {
            _view = view;
            _medicineRepository = medicineRepository;
            _staffRepository = staffRepository;
            _serviceRepository = serviceRepository;
        }
        public void DisplayStaffs()
        {
            //TODO: adding permissionOfStaff
            _view.AdminDataGridView.DataSource = GetStaffsToDisplay();
        }
        public void DisplayMedicines()
        {
            _view.AdminDataGridView.DataSource = GetMedicinesToDisplay();
        }
        public void DisplayServices()
        {
            _view.AdminDataGridView.DataSource = GetServicesToDisplay();
        }
        private BindingSource GetServicesToDisplay()
        {
            BindingSource servicesBindingSource = new BindingSource();
            servicesBindingSource.DataSource = _serviceRepository.GetServiceList();
            return servicesBindingSource;
        }
        private BindingSource GetStaffsToDisplay()
        {
            BindingSource staffsBindingSource = new BindingSource();
            staffsBindingSource.DataSource = _staffRepository.GetStaffList();
            return staffsBindingSource;
        }
        private BindingSource GetMedicinesToDisplay()
        {
            BindingSource medicinesBindingSource = new BindingSource();
            medicinesBindingSource.DataSource = _medicineRepository.GetMedicineList();
            return medicinesBindingSource;
        }
        public void SearchMedicines()
        {
            _view.AdminDataGridView.DataSource = _medicineRepository.GetMedicinesByName(_view.TxtTimKiem);
        }
    }
}
