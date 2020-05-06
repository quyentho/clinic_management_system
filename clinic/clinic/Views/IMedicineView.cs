using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace clinic.Views
{
    public interface IMedicineView
    {
        string TxtMedicineName { get; set; }
        string TxtEntryQuantity { get; set; }
        string TxtEntryUnit { get; set; }
        string TxtEntryPrice { get; set; }
        string TxtSaleUnit { get; set; }
        string TxtSalePrice { get; set; }
        string TxtExpiryDay { get; set; }
        string TxtExchangeRatio { get; set; }
    }
}
