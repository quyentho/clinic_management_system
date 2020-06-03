using System;

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
        public void AddPrescriptionToDatabase(prescription prescription, ref string errMessage)
        {
            try
            {
                _medicineRepository.MinusQuantity(prescription.medicine_id, prescription.quantity_indicated);
                _clinicEntities.prescriptions.Add(prescription);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errMessage = ex.Message;
            }
        }
    }
}