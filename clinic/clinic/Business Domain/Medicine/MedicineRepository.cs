﻿using System;
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
        private List<medicine> _medicineList;
        public MedicineRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _medicineList = GetMedicinesFromDatabase();
        }
        public void Delete(int id)
        {
            var medicineFromDb = _clinicEntities.medicines.Find(id);
            if (medicineFromDb != null)
            {
                _medicineList.Remove(GetMedicineById(id));
                _clinicEntities.medicines.Remove(medicineFromDb);
                Save();
            }
        }

        public medicine GetMedicineById(int id)
        {
            var medicine = _medicineList.Where(m => m.id == id).FirstOrDefault();
            return medicine;
        }

        public List<medicine> GetMedicinesByName(string medicineName)
        {
            var medicines = _medicineList.Where(m => m.medicine_name.Contains(medicineName)).ToList();
            return medicines;
        }

        private List<medicine> GetMedicinesFromDatabase()
        {
            return _clinicEntities.medicines.Where(m => m.is_active == true).ToList();
        }
        public List<medicine> GetAll()
        {
            return _medicineList;
        }
        public void Insert(medicine medicine)
        {
            _medicineList.Add(medicine);
            _clinicEntities.medicines.Add(medicine);
            Save();
        }

        private void Save()
        {
            _clinicEntities.SaveChanges();
        }

        public void Update(medicine medicineChanged)
        {

            int indexToReplace = (_medicineList).FindIndex(m => m.id == medicineChanged.id);

            _medicineList[indexToReplace] = medicineChanged;//replace this way for refresh list immediately

            var medicineFromDb = _clinicEntities.medicines.Find(medicineChanged.id);
            if (medicineFromDb != null)
            {
                medicineChanged.entry_day = medicineFromDb.entry_day;
                medicineChanged.quantity_in_sale_unit = medicineFromDb.quantity_in_sale_unit;
                _clinicEntities.Entry(medicineFromDb).CurrentValues.SetValues(medicineChanged);
                Save();
            }
        }

        

        public void DecreaseQuantity(int medicineId, int quantity)
        {
            var medicine = GetMedicineById(medicineId);
            if (medicine.quantity_in_sale_unit - quantity < 0)
                throw new ArgumentOutOfRangeException("quantity", "Đã hết thuốc trong kho");

            medicine.quantity_in_sale_unit -= quantity;

            Update(medicine);
        }
    }
}
