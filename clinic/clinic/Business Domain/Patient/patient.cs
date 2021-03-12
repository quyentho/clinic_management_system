namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patient()
        {
            bills = new HashSet<bill>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string patient_name { get; set; }

        public int? age { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [Required]
        [StringLength(15)]
        public string phone_number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }
    }
}
