using System;
using System.ComponentModel;

namespace clinic.BusinessDomain.Medicine
{
    public class AdminMedicineVM
    {
        public int Id { get; set; }

        [DisplayName("Tên thuốc")]
        public string Name { get; set; }

        [DisplayName("Giá bán")]
        public string SalePrice { get; set; }

        [DisplayName("Số lượng tồn kho")]
        public string Quantity { get; set; }

        [DisplayName("Đơn vị bán")]
        public string SaleUnit { get; set; }

        [DisplayName("Số lượng nhập")]
        public string EntryQuantity { get; set; }
        
        [DisplayName("Đơn vị nhập")]
        public string EntryUnit { get; set; }

        [DisplayName("Ngày nhập")]
        public DateTime? EntryDate { get; set; }

        [DisplayName("Ngày xuất")]
        public DateTime? ExpiryDate { get; set; }

        [DisplayName("Tỷ lệ chuyển đổi")]
        public string ExchangeRatio { get; set; }
    }
}
