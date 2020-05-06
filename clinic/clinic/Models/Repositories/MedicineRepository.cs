using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace clinic.Models.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly clinicEntities _clinicEntities;
        private IList<medicine> _medicines;
        public MedicineRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _medicines = GetMedicinesFromDatabase();
        }
        //TODO: try catch and Logging for delete and update method
        public void DeleteMedicine(medicine medicine)
        {
            _medicines.Remove(medicine);
            //BUG When Delete after update
            //if (!_clinicEntities.medicines.Local.Contains(medicine))
            //{
            //    _clinicEntities.medicines.Attach(medicine);
            //}
            _clinicEntities.Entry(medicine).State = System.Data.Entity.EntityState.Deleted;
        }

        public medicine GetMedicineById(int id)
        {
            var medicine = _medicines.Where(m => m.id == id).FirstOrDefault();
            return medicine;
        }

        public IList<medicine> GetMedicinesByName(string medicineName)
        {
            var medicines = _medicines.Where(m => m.medicine_name.Contains(medicineName)).ToList();
            return medicines;
        }

        private IList<medicine> GetMedicinesFromDatabase()
        {
            return _clinicEntities.medicines.Where(m => m.is_active == true).ToList();
        }
        public IList<medicine> GetMedicineList()
        {
            return _medicines;
        }

        public void InsertMedicine(medicine medicine)
        {
            _medicines.Add(medicine);
            _clinicEntities.medicines.Add(medicine);
        }

        public void Save()
        {
            _clinicEntities.SaveChanges();
        }

        public void UpdateMedicine(medicine medicine)
        {

            int indexToReplace = (_medicines as List<medicine>).FindIndex(m => m.id == medicine.id);

            _medicines[indexToReplace] = medicine;
            Console.WriteLine($" From Update Method before update: {_clinicEntities.Entry(medicine).State}");

            //update medicine in database
            _clinicEntities.Set<medicine>().AddOrUpdate(medicine);
            Console.WriteLine($" From Update Method after update: {_clinicEntities.Entry(medicine).State}");
        }
    }
}
