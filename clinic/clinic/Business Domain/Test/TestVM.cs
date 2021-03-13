using System;
using System.ComponentModel;

namespace clinic.BusinessDomain.Statistic
{
    public class TestVM
    {
        [DisplayName("Mã dịch vụ")]
        public int ServiceId { get; set; }
        
        [DisplayName("Tên dịch vụ")]
        public string ServiceName { get; set; }
        
        [DisplayName("Mã thuốc")]
        public int MedicineId { get; set; }
        [DisplayName("Tên thuốc")]

        public string MedicineName { get; set; }
        
        [DisplayName("Số ca sử dụng")]
        public int Count { get; set; } = 0;
        
        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Ngày kết thúc")]

        public DateTime? EndDate { get; set; }
    }
}
