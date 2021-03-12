namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            accounts = new HashSet<account>();
            bills = new HashSet<bill>();
            prescriptions = new HashSet<prescription>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string full_name { get; set; }

        public DateTime? date_of_birth { get; set; }

        [StringLength(15)]
        public string phone_number { get; set; }

        public long? salary { get; set; }

        public bool is_still_working { get; set; }

        public int permission_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> accounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        public virtual permission permission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prescription> prescriptions { get; set; }
    }
}
