using clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic.Views
{
    public interface IPrescriptionView
    {
        object DgvMedicineDataSource { get; set; }
        List<prescription> ListPrescriptionOfMedicineSelected { get; set; }
        int PatientId { get; set; }
        int IdMedicineSelected { get; set; }
        int IndexRemove { get; set; }
        DataGridView DgvMedicinesSelected { get; set; }
        string TxtSearch { get; set; }
        string Descriptions { get; set; }
        int Quantity { get; set; }
        string ErrMessage { get; set; }
    }
}
