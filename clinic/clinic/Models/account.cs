//------------------------------------------------------------------------------
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
    
    public partial class account
    {
        public int id { get; set; }
        public int staff_id { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public int permission_id { get; set; }
        public bool is_active { get; set; }
    
        public virtual permission permission { get; set; }
        public virtual staff staff { get; set; }
    }
}
