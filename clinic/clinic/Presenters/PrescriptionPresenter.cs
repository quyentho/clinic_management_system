using clinic.BusinessDomain.Medicine;
using clinic.Models;
using clinic.Utilities;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace clinic.Presenters
{
    public class PrescriptionPresenter
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IBillRepository _billRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IPrescriptionView _view;

        private List<prescription> _temporaryPrescription = new List<prescription>();
        private List<MedicineAssignedVM> _selectedMedicineList = new List<MedicineAssignedVM>();
        public PrescriptionPresenter(IMedicineRepository repository, IBillRepository billRepository, IPrescriptionRepository prescriptionRepository, IPrescriptionView view)
        {
            _medicineRepository = repository;
            _billRepository = billRepository;
            _prescriptionRepository = prescriptionRepository;
            _view = view;

            DisplayMedicineDataGridView();
        }

        public void DisplayMedicineDataGridView()
        {
            var medicineVMs = GetMedicineVMs();
            _view.DgvMedicineDataSource = medicineVMs;
        }

        private List<MedicineVM> GetMedicineVMs()
        {
            List<MedicineVM> medicineVMs = new List<MedicineVM>();
            foreach (var medicine in _medicineRepository.GetAll())
            {
               medicineVMs.Add(Transform.MedicineTransform(medicine));
            }
            return medicineVMs;
        }

        public void AssignMedicine()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);

            var prescriptionItem = AddMedicineToPrescription(bill.id, _view.MedicineSelectedId);

            if (!_temporaryPrescription.Any(p=>p.medicine_id == prescriptionItem.medicine_id))
            {
                _temporaryPrescription.Add(prescriptionItem);

                MedicineAssignedVM medicineSelected = GetMedicineViewModel(prescriptionItem);

                DisplayMedicineSelected(medicineSelected);
            }
        }

        public void LoadExistingPrescription(int patientId)
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(patientId);

            _temporaryPrescription = _prescriptionRepository.GetPrescriptionByBillId(bill.id);

            foreach (var item in _temporaryPrescription)
            {
                var medicineVM = GetMedicineViewModel(item);

                DisplayMedicineSelected(medicineVM);
            }

        }

        private MedicineAssignedVM GetMedicineViewModel(prescription prescriptionItem)
        {
            medicine med = _medicineRepository.GetMedicineById(prescriptionItem.medicine_id);

            return new MedicineAssignedVM()
            {
                Name = med.medicine_name,
                Description = prescriptionItem.description,
                Quantity = prescriptionItem.quantity_indicated.ToString(),
                SalePrice = med.sale_price_per_unit.ToString(),
                Unit = med.sale_unit
            };

        }

        private void DisplayMedicineSelected(MedicineAssignedVM medicineSelected)
        {
            _selectedMedicineList.Add(medicineSelected);

            RefreshDatagridView();
        }

        private void RefreshDatagridView()
        {
            _view.DgvMedicinesSelectedDatasource = typeof(List<MedicineAssignedVM>);
            _view.DgvMedicinesSelectedDatasource = _selectedMedicineList;
        }

        public void RemoveMedicineAssigned()
        {
            _selectedMedicineList.RemoveAt(_view.IndexRemove);
            _temporaryPrescription.RemoveAt(_view.IndexRemove);

            RefreshDatagridView();
        }

        public void AddPresciptionToBill()
        {
            var bill = _billRepository.GetUnpaidBillByPatientId(_view.PatientId);
           
            // clear presciption in case of update.
            _prescriptionRepository.ClearPresciptionInBill(bill);

            foreach (prescription prescriptionItem in _temporaryPrescription)
            {
                if (!bill.prescriptions.Contains(prescriptionItem))
                {
                    try
                    {
                        _prescriptionRepository.AddPrescriptionToDatabase(prescriptionItem);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        _view.ErrMessage = ex.Message;
                    }
                }
            }
            
            _billRepository.CalculateTotalMoneyInBill(bill.id);
        }
        private prescription AddMedicineToPrescription(int billId, int medicineId)
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
