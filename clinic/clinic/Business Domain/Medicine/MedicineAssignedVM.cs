using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.BusinessDomain.Medicine
{
    public class MedicineAssignedVM
    {
        [DisplayName("Tên thuốc")]
        public string Name { get; set; }

        [DisplayName("Giá bán")]
        public string SalePrice { get; set; }

        [DisplayName("Số lượng")]
        public string Quantity { get; set; }

        [DisplayName("Đơn vị")]
        public string Unit { get; set; }

        [DisplayName("HDSD")]
        public string Description { get; set; }
    }
}
