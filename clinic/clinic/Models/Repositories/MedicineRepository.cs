using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using clinic.Models;
namespace clinic.Models.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly clinicEntities _clinicEntities;
        private List<medicine> _medicines;
        public MedicineRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _medicines = GetMedicinesFromDatabase();
        }
        public void DeleteMedicine(int id)
        {   
            var medicineFromDb = _clinicEntities.medicines.Find(id);
            
            _medicines.Remove(GetMedicineById(id));
            _clinicEntities.medicines.Remove(medicineFromDb);
        }

        public medicine GetMedicineById(int id)
        {
            var medicine = _medicines.Where(m => m.id == id).FirstOrDefault();
            return medicine;
        }

        public List<medicine> GetMedicinesByName(string medicineName)
        {
            var medicines = _medicines.Where(m => m.medicine_name.Contains(medicineName)).ToList();
            return medicines;
        }

        private List<medicine> GetMedicinesFromDatabase()
        {
            return _clinicEntities.medicines.Where(m => m.is_active == true).ToList();
        }
        public List<medicine> GetMedicineList()
        {
            return _medicines;
        }
        public void InsertMedicine(medicine medicine)
        {
            _medicines.Add(medicine);
            _clinicEntities.medicines.Add(medicine);
            Save();
        }

        private void Save()
        {
            _clinicEntities.SaveChanges();
        }

        public void UpdateMedicine(medicine medicineChanged)
        {
            int indexToReplace = (_medicines ).FindIndex(m => m.id == medicineChanged.id);

            _medicines[indexToReplace] = medicineChanged;//replace this way for refresh list immediately

            var medicineFromDb = _clinicEntities.medicines.Find(medicineChanged.id);
            if (medicineFromDb != null)
            {
                _clinicEntities.AddOrUpdateEntity<medicine>(_clinicEntities, medicineChanged);
                Save();
            }
        }
    }
}
