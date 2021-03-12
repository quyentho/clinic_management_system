using System.ComponentModel.DataAnnotations;

namespace clinic
{
    public partial class account
    {
        public int id { get; set; }

        public int staff_id { get; set; }

        [Required]
        [StringLength(15)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string pass { get; set; }

        public int permission_id { get; set; }

        public bool is_active { get; set; }

        public virtual permission permission { get; set; }

        public virtual staff staff { get; set; }
    }
}
