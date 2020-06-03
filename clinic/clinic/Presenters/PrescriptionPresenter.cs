using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public class PrescriptionPresenter
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IBillRepository _billRepository;
        private readonly IPrescriptionView _view;
        public PrescriptionPresenter(IMedicineRepository repository, IBillRepository billRepository, IPrescriptionView view)
        {
            _medicineRepository = repository;
            _billRepository = billRepository;
            _view = view;

            DisplayMedicineDataGridView();
        }

        public void DisplayMedicineDataGridView()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
            HashSet<int> medicineAssignedIds = new HashSet<int>(bill.prescriptions.Select(p => p.medicine_id));

            List<medicine> medicineToDisplay = _medicineRepository.GetMedicineList()
                .Where(s => !medicineAssignedIds.Contains(s.id)).ToList(); // Not display medicine  
                                                                           // already assinged                    
            _view.DgvMedicineDataSource = medicineToDisplay;
        }
        public void AssignMedicine()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);

            var prescription = CreatePresciption(bill.id, _view.IdMedicineSelected);

            if (!(_view.ListPrescriptionOfMedicineSelected.Contains(prescription)))
            {
                _view.ListPrescriptionOfMedicineSelected.Add(prescription);

                var medicineSelected = _medicineRepository.GetMedicineById(_view.IdMedicineSelected);
                DisplayMedicineSelected(medicineSelected);
            }


        }

        private void DisplayMedicineSelected(medicine medicineSelected)
        {
            _view.DgvMedicinesSelected.Rows.Add(medicineSelected.medicine_name, medicineSelected.sale_price_per_unit, _view.Quantity, _view.Descriptions);
        }

        public void RemoveMedicineAssigned()
        {
            _view.DgvMedicinesSelected.Rows.RemoveAt(_view.IndexRemove);
            _view.ListPrescriptionOfMedicineSelected.RemoveAt(_view.IndexRemove);
        }

        public void AddPresciptionToBillIfExists()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
            if (_view.ListPrescriptionOfMedicineSelected.Count > 0)
            {
                foreach (prescription prescription in _view.ListPrescriptionOfMedicineSelected)
                {
                    try
                    {
                        _billRepository.AddPrescriptionToBill(bill.id, prescription);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        _view.ErrMessage = ex.Message;
                    }
                }
            }
            _billRepository.CalculateTotalMoneyInBill(bill.id);
        }
        private prescription CreatePresciption(int billId, int medicineId)
        {
            prescription prescription = new prescription()
            {
                bill_id = billId,
                medicine_id = medicineId,
                date_created = DateTime.Now,
                quantity_indicated = _view.Quantity,
                description = _view.Descriptions,
                staff_id = Program.staffId
            };
            return prescription;
        }

        public void SearchMedicine()
        {
            _view.DgvMedicineDataSource = _medicineRepository.GetMedicinesByName(_view.TxtSearch);
        }
    }
}
