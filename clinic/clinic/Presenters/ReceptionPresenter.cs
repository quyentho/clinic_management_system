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
            var listUnpaidBill = _billRepository.GetListUnpaidBill();

            _view.DgvReceptionDataSource = BillsToDisPlay(listUnpaidBill);
        }
        private List<BillViewModel> BillsToDisPlay(List<bill> ListBill)
        {
            var listBillVM = new List<BillViewModel>();
            foreach (var bill in ListBill)
            {
                listBillVM.Add(new BillViewModel()
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
                if (_view.Functionality == ReceptionFunctionalityEnum.Bill)
                    _view.DgvReceptionDataSource = _billRepository.GetUnpaidBillByPhoneNumber(_view.TxtSearch);
                if (_view.Functionality == ReceptionFunctionalityEnum.Patient)
                    _view.DgvReceptionDataSource = _patientRepository.GetPatientsByPhone(_view.TxtSearch);
            }
            if (_view.CbSearchValue == "Tên")
            {
                if (_view.Functionality == ReceptionFunctionalityEnum.Bill)
                    _view.DgvReceptionDataSource = _billRepository.GetUnpaidBillsByPatientName(_view.TxtSearch);
                if (_view.Functionality == ReceptionFunctionalityEnum.Patient)
                    _view.DgvReceptionDataSource = _patientRepository.GetPatientsByName(_view.TxtSearch);
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
