using System;
using System.Collections.Generic;
using System.Linq;

namespace clinic.Models.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private clinicEntities _clinicEntities;
        private IMedicineRepository _medicineRepository;

        public PrescriptionRepository(clinicEntities dbContext, IMedicineRepository medicineRepository)
        { 
            _clinicEntities = dbContext;
            _medicineRepository = medicineRepository;
        }
        public void AddPrescriptionToDatabase(prescription prescription)
        {
                _medicineRepository.DecreaseQuantity(prescription.medicine_id, prescription.quantity_indicated);
                _clinicEntities.prescriptions.Add(prescription);
        }

        public void ClearPresciptionInBill(bill bill)
        {
            bill.prescriptions.Clear();
            _clinicEntities.SaveChanges();
        }

        public List<prescription> GetPrescriptionByBillId(int billId)
        {
            return _clinicEntities.prescriptions.Where(p => p.bill_id == billId).ToList();
        }
    }
}