﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patient()
        {
            this.bills = new HashSet<bill>();
        }
    
        public int id { get; set; }
        [DisplayName("Tên bệnh nhân")]
        public string patient_name { get; set; }
        [DisplayName("Tuổi")]
        public Nullable<int> age { get; set; }
        [DisplayName("Giới Tính")]
        public string gender { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string phone_number { get; set; }
        [Browsable(false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }
    }
}
