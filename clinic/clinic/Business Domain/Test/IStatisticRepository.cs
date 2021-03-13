using System.Collections.Generic;

namespace clinic.BusinessDomain.Statistic
{
    public interface IStatisticRepository
    {
        List<ServiceStatistic> GetAllActive();
        void InitializeNewRecord(int serviceId, int medicineId);
    }
}