﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IPrescriptionRepository
    {
        void CreatePrescription(prescription prescription, ref string errMessage);
    }
}
