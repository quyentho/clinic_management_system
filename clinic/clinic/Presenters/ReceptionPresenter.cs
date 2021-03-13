using clinic.BusinessDomain.Patient;
using clinic.Models;
using clinic.Models.Repositories;
using clinic.Utilities;
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
        public void DisplayPatients()
        {

            _view.DgvReceptionDataSource = null;

            var patients = _patientRepository.GetPatients();

            _view.DgvReceptionDataSource = GetPatientVMs(patients);
        }

        private List<PatientVM> GetPatientVMs(List<patient> patients)
        {
            List<PatientVM> patientVMs = new List<PatientVM>();
            foreach (var patient in patients)
            {
                patientVMs.Add(Transform.PatientTransform(patient));
            }
            return patientVMs;
        }

        public void DisplayUnpaidBills()
        {
            _view.DgvReceptionDataSource = null;
            var listUnpaidBill = _billRepository.GetListUnpaidBill();

            _view.DgvReceptionDataSource = BillsToDisPlay(listUnpaidBill);
        }
        private List<BillVM> BillsToDisPlay(List<bill> ListBill)
        {
            var listBillVM = new List<BillVM>();
            foreach (var bill in ListBill)
            {
                listBillVM.Add(new BillVM()
                {
                    Id = bill.id,
                    PatientId = bill.patient_id,
                    DateCreated = bill.created_at,
                    PatientName = bill.patient.patient_name,
                    StaffName = bill.staff.full_name,
                    TotalMoney = bill.total_money
                });
            }
            return listBillVM;
        }
        public void PayBill()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientIdSelected);
            _billRepository.PayBill(bill.id);
        }
        public void Search()
        {
            if (_view.CbSearchValue == "SDT")
            {
                switch (_view.Functionality)
                {
                    case ReceptionFunctionalityEnum.Patient:
                        var patients = _patientRepository.GetPatientsByPhone(_view.TxtSearch);
                        _view.DgvReceptionDataSource = GetPatientVMs(patients);
                        break;
                    case ReceptionFunctionalityEnum.Bill:
                        _view.DgvReceptionDataSource = _billRepository.GetUnpaidBillByPhoneNumber(_view.TxtSearch);
                        break;
                }
            }
            else if (_view.CbSearchValue == "Tên")
            {
                switch (_view.Functionality)
                {
                    case ReceptionFunctionalityEnum.Patient:
                        var patients = _patientRepository.GetPatientsByName(_view.TxtSearch);
                        _view.DgvReceptionDataSource = GetPatientVMs(patients);
                        break;
                    case ReceptionFunctionalityEnum.Bill:
                        _view.DgvReceptionDataSource = _billRepository.GetUnpaidBillsByPatientName(_view.TxtSearch);
                        break;
                }

            }
        }
        public void CreateBillIfNotExists()
        {
            if (_view.Functionality == ReceptionFunctionalityEnum.Patient)
            {
                var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientIdSelected);
                if (bill is null)
                {
                    bill = new bill()
                    {
                        created_at = DateTime.Now,
                        is_paid = false,
                        patient_id = _view.PatientIdSelected,
                        total_money = 0,
                        staff_created = Program.staffId
                    };
                    _billRepository.CreateBill(bill);
                }
            }
        }
    }
}
