using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.BusinessDomain.Service
{
    public class ServiceVM
    {
        public int Id { get; set; }

        [DisplayName("Tên dịch vụ")]
        public string Name { get; set; }

        [DisplayName("Giá")]
        public string Price { get; set; }
        
        [DisplayName("Loại dịch vụ")]
        public string Type { get; set; }

        [DisplayName("Thuốc sử dụng")]
        public string MedicineUsage { get; set; }
    }
}
