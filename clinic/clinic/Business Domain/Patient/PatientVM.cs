using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.BusinessDomain.Patient
{
    public class PatientVM
    {
        public string Id { get; set; }

        [DisplayName("Tên bệnh nhân")]
        public string Name { get; set; }

        [DisplayName("Tuổi")]
        public string Age { get; set; }

        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [DisplayName("SDT")]
        public string PhoneNumber { get; set; }
    }
}
