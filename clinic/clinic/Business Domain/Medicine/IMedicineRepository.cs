﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IMedicineRepository
    {
        List<medicine> GetAll();
        medicine GetMedicineById(int id);
        List<medicine> GetMedicinesByName(string name);
        void InsertMedicine(medicine medicine);
        void DeleteMedicine(int id);
        void UpdateMedicine(medicine medicine);
        void DecreaseQuantity(int medicineId, int quantity);
    }
}
