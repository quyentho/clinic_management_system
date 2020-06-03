using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public class BillViewModel
    {
        [DisplayName("Mã Hóa Đơn")]
        public int Id { get; set; }
        [DisplayName("Mã Bệnh Nhân")]
        public int PatientId { get; set; }
        [DisplayName("Tên Bệnh Nhân")]
        public string PatientName { get; set; }
        [DisplayName("Ngày Tạo")]
        public DateTime DateCreated { get; set; }
        [DisplayName("Nhân Viên Tạo")]
        public string StaffName { get; set; }
        [DisplayName("Tổng Tiền")]
        public long TotalMoney { get; set; }

    }
}
