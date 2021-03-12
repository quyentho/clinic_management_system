namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class clinic_service
    {
        public clinic_service()
        {
            bills = new HashSet<bill>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string service_name { get; set; }

        public long price { get; set; }

        public bool? is_active { get; set; }

        public string Type { get; set; }

        [ForeignKey("medicine")]
        public int? Medicine_Id { get; set; }
        public medicine medicine { get; set; }

        public virtual ICollection<bill> bills { get; set; }
    }
}
