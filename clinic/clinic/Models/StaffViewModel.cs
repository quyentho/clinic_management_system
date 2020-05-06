using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace clinic.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        [DisplayName("Tên Nhân Viên")]
        public string FullName { get; set; }
        [DisplayName("Ngày Sinh")]
        public string DateOfBirth { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string PhoneNumber { get; set; }
        [DisplayName("Lương Cơ Bản")]
        public Int64 Salary { get; set; }
        [DisplayName("Chức Vụ")]
        public string PositionName { get; set; }
    }
}
