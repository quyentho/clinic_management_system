using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public class RevenueViewModel
    {
        [DisplayName("Tổng Doanh Thu")]
        public long Revenue { get; set; }
        [DisplayName("Ngày/Tháng/Năm")]
        public string Date { get; set; }
    }
}
