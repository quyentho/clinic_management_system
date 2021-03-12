namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            prescriptions = new HashSet<prescription>();
            clinic_service = new HashSet<clinic_service>();
        }

        public int id { get; set; }

        public int patient_id { get; set; }

        public DateTime created_at { get; set; }

        public int staff_created { get; set; }

        public long total_money { get; set; }

        public bool is_paid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prescription> prescriptions { get; set; }

        public virtual patient patient { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clinic_service> clinic_service { get; set; }
    }
}
