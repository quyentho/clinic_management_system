using System.Windows.Forms;

namespace clinic.Views
{
    public interface IStaffView
    {
        int CbPermission_id { get; set; }
        string TxtStaffName { get; set; }
        string TxtDoB { get; set; }
        string TxtPhone { get; set; }
        string TxtSalary { get; set; }
        ComboBox CbPermission { get; set; }
    }
}
