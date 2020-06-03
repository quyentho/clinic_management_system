using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IReceptionView
    {
        string TxtSearch { get; set; }
        int PatientIdSelected { get; set; }
        
        object DgvReceptionDataSource { get; set; }
        string CbSearchValue { get; }
        ReceptionFunctionalityEnum Functionality { get;set; }
    }
}
