﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace clinic.Views
{
    interface IMedicineView
    {
        string TxtMedicineName { get; set; }
        string TxtQuantity { get; set; }
        string TxtUnit { get; set; }
        string TxtPrice { get; set; }
        string ErrorMessage { get; set; }
        bool IsEdit { get; set; }
        int IdSelected { get; set; }
        bool IsDelete { get; set; }
     
    }
}
