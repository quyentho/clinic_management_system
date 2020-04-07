using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly clinicEntities _clinicEntities;
        public ServiceRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
        }
        public void DeleteService(clinic_service clinic_service)
        {
            _clinicEntities.clinic_service.Remove(clinic_service);
        }

        public clinic_service GetServiceById(int id)
        {
            clinic_service medicineFromDb = _clinicEntities.clinic_service.FirstOrDefault(clinic_service => clinic_service.id == id);

            return medicineFromDb;
        }

        public async Task<IEnumerable<clinic_service>> GetServices()
        {
            return await Task.Run(() => _clinicEntities.clinic_service.ToList());
        }

        public void InsertService(clinic_service clinic_service)
        {
            _clinicEntities.clinic_service.Add(clinic_service);
        }

        public async Task Save()
        {
            await _clinicEntities.SaveChangesAsync();
        }

        public void UpdateService(clinic_service clinic_service)
        {
            _clinicEntities.Entry(clinic_service).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
