using System;
using System.Collections.Generic;

namespace clinic
{
    public partial class bill
    {
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

        public virtual ICollection<prescription> prescriptions { get; set; }

        public virtual patient patient { get; set; }

        public virtual staff staff { get; set; }

        public virtual ICollection<clinic_service> clinic_service { get; set; }
    }
}
