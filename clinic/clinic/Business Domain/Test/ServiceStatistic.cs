using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic.BusinessDomain.Statistic
{
    public class ServiceStatistic
    {
        public int Id { get; set; }
    
        [ForeignKey("clinic_service")]
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        public clinic_service clinic_service { get; set; }
        public medicine medicine { get; set; }
    }
}
