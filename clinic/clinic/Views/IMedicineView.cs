using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models.Bussiness_Logics;
namespace clinic.Views
{
    interface IMedicineView
    {
        string TxtTenThuoc { get; set; }
        string TxtSoLuong { get; set; }
        string TxtDonVi { get; set; }
        string TxtGia { get; set; }
        string ErrorMessage { get; set; }
        bool IsEdit { get; set; }
        int IdSelected { get; set; }
        bool IsDelete { get; set; }
     
    }
}
