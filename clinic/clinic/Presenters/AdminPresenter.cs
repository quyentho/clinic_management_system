using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Views;
using clinic.Models;
namespace clinic.Presenters
{
    class AdminPresenter
    {
        private IAdminView _adminView;
        private readonly clinicEntities _clinicEntities;
        public AdminPresenter(IAdminView view, clinicEntities clinicEntities)
        {
            _adminView = view;
            _clinicEntities = clinicEntities;
        }
        public async Task<IEnumerable<medicine>> GetMedicineData()
        {
            var medicines = Task.Run(() => _clinicEntities.medicines.ToList());
            return await medicines;
        }
        public async Task<IEnumerable<medicine>> SearchMedicines(string txtSearch)
        {
            _adminView.TxtTimKiem = txtSearch;

            var medicines =Task.Run(()=> _clinicEntities.medicines.Where(m => m.medicine_name == txtSearch).ToList());
            return await medicines;
        }
        public async Task<IEnumerable<clinic_service>> GetServiceData()
        {
            var services =Task.Run(() => _clinicEntities.clinic_service.ToList());
            return await services;
        }
    }
}
