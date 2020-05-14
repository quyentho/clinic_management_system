using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly clinicEntities _clinicEntities;
        private List<clinic_service> _clinic_service;
        public ServiceRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _clinic_service = GetServicesFromDatabase();
        }
        public void DeleteService(clinic_service clinic_service)
        {
            _clinic_service.Remove(clinic_service);
            if (!_clinicEntities.clinic_service.Local.Contains(clinic_service))
            {
                _clinicEntities.clinic_service.Attach(clinic_service);
            }
            _clinicEntities.clinic_service.Remove(clinic_service);
        }

        public clinic_service GetServiceById(int id)
        {
            var clinic_service = _clinic_service.Where(m => m.id == id).FirstOrDefault();
            return clinic_service;
        }

        public List<clinic_service> GetServicesByName(string clinic_serviceName)
        {
            var clinic_service = _clinic_service.Where(m => m.service_name.Contains(clinic_serviceName)).ToList();
            return clinic_service;
        }

        private List<clinic_service> GetServicesFromDatabase()
        {
            return _clinicEntities.clinic_service.Where(m => m.is_active == true).AsNoTracking().ToList();
        }
        public List<clinic_service> GetServiceList()
        {
            return _clinic_service;
        }

        public void InsertService(clinic_service clinic_service)
        {
            _clinic_service.Add(clinic_service);
            _clinicEntities.clinic_service.Add(clinic_service);
        }

        public void Save()
        {
            _clinicEntities.SaveChanges();
        }

        public void UpdateService(clinic_service clinic_service)
        {
            var clinic_serviceFromList = _clinic_service.FirstOrDefault(m => m.id == clinic_service.id);
            clinic_serviceFromList = clinic_service;

            _clinicEntities.Set<clinic_service>().AddOrUpdate(clinic_service);
        }
    }
}
