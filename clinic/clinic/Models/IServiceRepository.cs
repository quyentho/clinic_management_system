using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IServiceRepository
    {
        List<clinic_service> GetServiceList();
        List<clinic_service> GetServicesByName(string name);
        clinic_service GetServiceById(int id);
        void InsertService(clinic_service clinic_service);
        void DeleteService(clinic_service clinic_service);
        void UpdateService(clinic_service clinic_service);
        void Save();
    }
}
