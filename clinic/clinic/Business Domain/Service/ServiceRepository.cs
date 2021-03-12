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
        private List<clinic_service> _serviceList;
        
        public ServiceRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _serviceList = GetServicesFromDatabase();
        }

        public clinic_service GetServiceById(int id)
        {
            var clinic_service = _serviceList.Where(m => m.id == id).FirstOrDefault();
            return clinic_service;
        }

        public List<clinic_service> GetServicesByName(string clinic_serviceName)
        {
            var clinic_service = _serviceList.Where(m => m.service_name.Contains(clinic_serviceName)).ToList();
            return clinic_service;
        }

        private List<clinic_service> GetServicesFromDatabase()
        {
            return _clinicEntities.clinic_service.Where(m => m.is_active == true).AsNoTracking().ToList();
        }
        public List<clinic_service> GetServiceList()
        {
            return _serviceList;
        }

        public void Insert(clinic_service clinic_service)
        {
            _serviceList.Add(clinic_service);
            _clinicEntities.clinic_service.Add(clinic_service);
            Save();
        }
        public void Delete(int id)
        {
            var serviceFromDb = _clinicEntities.clinic_service.Find(id);
            if (serviceFromDb != null)
            {
                _serviceList.Remove(GetServiceById(id));
                _clinicEntities.clinic_service.Remove(serviceFromDb);
               
              
                Save();
            }

        }

        public void Update(clinic_service serviceChanged)
        {
            int indexToReplace = (_serviceList).FindIndex(m => m.id == serviceChanged.id);

            _serviceList[indexToReplace] = serviceChanged;//replace this way for refresh list immediately

            var serviceFromDb = _clinicEntities.clinic_service.Find(serviceChanged.id);
            if (serviceFromDb != null)
            {
                _clinicEntities.clinic_service.Remove(serviceFromDb);
                _clinicEntities.clinic_service.Add(serviceChanged);
                Save();
            }
        }

        private void Save()
        {
            _clinicEntities.SaveChanges();
        }
    }
}
