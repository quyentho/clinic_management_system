using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.BusinessDomain.Statistic
{
    public class ServiceStatistic
    {
        public int Id { get; set; }
    
        [ForeignKey("clinic_service")]
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public clinic_service clinic_service { get; set; }
        public medicine medicine { get; set; }
    }
}
