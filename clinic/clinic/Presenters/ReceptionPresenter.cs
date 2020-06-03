using clinic.Models;
using clinic.Models.Repositories;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public class ReceptionPresenter
    {
        private readonly clinicEntities _clinicEntities;
        private IPatientRepository _patientRepository;
        private IReceptionView _view;
        private IBillRepository _billRepository;
        public ReceptionPresenter(clinicEntities clinicEntities, IReceptionView view, IBillRepository billRepository, IPatientRepository patientRepository)
        {
           
            _clinicEntities = clinicEntities;
            _view = view;
            _billRepository = billRepository;
            _patientRepository = patientRepository;
        }
        public void DisplayPatientsData()
        {
            _view.DgvReceptionDataSource = null;
            _view.DgvReceptionDataSource = _patientRepository.GetPatientList();
        }
        public void DisplayListUnpaidBill()
        {
            _view.DgvReceptionDataSource = null;
            _view.DgvReceptionDataSource = _billRepository.GetListUnpaidBill();
        }
        public void PayBill()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientIdSelected);
            _billRepository.PayBill(bill.id);
        }
        public void Search()
        {
            if(_view.CbSearchValue == "SDT")
            {
                if (_view.Functionality == ReceptionFunctionalityEnum.Bill)
                   _view.DgvReceptionDataSource =  _billRepository.GetUnpaidBillByPhoneNumber(_view.TxtSearch);
                if (_view.Functionality == ReceptionFunctionalityEnum.Patient)
                    _view.DgvReceptionDataSource = _patientRepository.GetPatientsByPhone(_view.TxtSearch);
            }
            if(_view.CbSearchValue == "Tên")
            {
                if (_view.Functionality == ReceptionFunctionalityEnum.Bill)
                    _view.DgvReceptionDataSource = _billRepository.GetUnpaidBillsByPatientName(_view.TxtSearch);
                if (_view.Functionality == ReceptionFunctionalityEnum.Patient)
                    _view.DgvReceptionDataSource = _patientRepository.GetPatientsByName(_view.TxtSearch);
            }
        }

        public void CreateBillIfNotExists()
        {
            if(_view.Functionality == ReceptionFunctionalityEnum.Patient)
            {
                var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientIdSelected);
                if (bill is null)
                {
                    bill = new bill()
                    {
                        created_at = DateTime.UtcNow,
                        is_paid = false,
                        patient_id = _view.PatientIdSelected,
                        total_money = 0,
                        //HACK: Missing staff_created, will get from a static field when Login
                        staff_created = 3
                    };
                    _billRepository.CreateBill(bill);
                }
            }
        }
    }
}
