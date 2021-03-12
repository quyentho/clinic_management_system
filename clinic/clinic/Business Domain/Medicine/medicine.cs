namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicine()
        {
            prescriptions = new HashSet<prescription>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string medicine_name { get; set; }

        public int quantity_in_sale_unit { get; set; }

        [Required]
        [StringLength(50)]
        public string sale_unit { get; set; }

        public long sale_price_per_unit { get; set; }

        public bool? is_active { get; set; }

        public DateTime? expiry_day { get; set; }

        [StringLength(50)]
        public string entry_unit { get; set; }

        public long? entry_price { get; set; }

        public DateTime? entry_day { get; set; }

        public int? unit_exchange_ratio { get; set; }

        public int? quantity_in_entry_unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prescription> prescriptions { get; set; }
    }
}
