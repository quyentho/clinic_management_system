using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace clinic.BusinessDomain.Statistic
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly clinicEntities _clinicEntities;

        public StatisticRepository(clinicEntities clinicEntities)
        {
            this._clinicEntities = clinicEntities;
        }
        public List<ServiceStatistic> GetAllActive()
        {
            return _clinicEntities.ServiceStatistics
                .Include(s=>s.medicine)
                .Include(s=>s.clinic_service)
                .Where(s => s.IsActive == true)
                .ToList();
        }

        public void InitializeNewRecord(int serviceId, int medicineId)
        {
            var oldRecord = _clinicEntities.ServiceStatistics.Where(s => s.IsActive == true && s.ServiceId == serviceId).FirstOrDefault();
            oldRecord.IsActive = false;
            oldRecord.EndDate = DateTime.Now;

            _clinicEntities.ServiceStatistics.Add(new ServiceStatistic()
            {
                MedicineId = medicineId,
                ServiceId = serviceId,
                IsActive = true,
                StartDate = DateTime.Now,
                Count = 0,
            });

            _clinicEntities.SaveChanges();
        }
    }
}
