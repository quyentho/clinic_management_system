using System.Windows.Forms;

namespace clinic.Views
{
    interface IAdminView
    {

        DataGridView AdminDataGridView { get; set; }
        string TxtTimKiem { get; set; }
        int IndexSelected { get; set; }
    }
}
