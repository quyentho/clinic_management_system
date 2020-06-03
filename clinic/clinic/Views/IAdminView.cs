using System;
using System.Windows.Forms;

namespace clinic.Views
{
    public interface IAdminView
    {

        DataGridView AdminDataGridView { get; set; }
        string TxtTimKiem { get; set; }
        int IndexSelected { get; set; }
        DateTime DtpRevenue { get; set; }
        bool RbDate { get; set; }
        bool RbMonth { get; set; }
        bool RbYear { get; set; }
    }
}
