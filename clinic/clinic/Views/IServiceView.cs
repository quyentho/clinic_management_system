using System.Windows.Forms;

namespace clinic.Views
{
    interface IServiceView
    {
        string TxtServiceName { get; set; }
        string TxtPrice { get; set; }
        string ErrorMessage { get; set; }

        ComboBox CbServiceTypes { get; }

        int? SelectedMedicineId { get; set; }
    }
}
