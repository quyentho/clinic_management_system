namespace clinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prescription
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int medicine_id { get; set; }

        public int quantity_indicated { get; set; }

        public string description { get; set; }

        public int staff_id { get; set; }

        public DateTime date_created { get; set; }

        public virtual bill bill { get; set; }

        public virtual medicine medicine { get; set; }

        public virtual staff staff { get; set; }
    }
}
