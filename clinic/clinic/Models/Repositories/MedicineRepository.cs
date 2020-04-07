using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly clinicEntities _clinicEntities;
        public MedicineRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
        }
        public void DeleteMedicine(medicine medicine)
        {
                _clinicEntities.medicines.Remove(medicine);
        }

        public medicine GetMedicineById(int id)
        {
            medicine medicineFromDb = _clinicEntities.medicines.FirstOrDefault(medicine => medicine.id == id);

            return medicineFromDb;
        }

        public async Task<IEnumerable<medicine>> GetMedicines()
        {
            return await Task.Run( () => _clinicEntities.medicines.ToList());
        }

        public void InsertMedicine(medicine medicine)
        {
            _clinicEntities.medicines.Add(medicine);
        }

        public async Task Save()
        {
            await _clinicEntities.SaveChangesAsync();
        }

        public void UpdateMedicine(medicine medicine)
        {
            _clinicEntities.Entry(medicine).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
