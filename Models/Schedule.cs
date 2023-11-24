//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.BookingPatients = new HashSet<BookingPatient>();
        }
    
        public string ScheduleID { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<int> MaxNumber { get; set; }
        public Nullable<int> CurrentNumber { get; set; }
        public string DoctorID { get; set; }
        public string HourID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingPatient> BookingPatients { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Hour Hour { get; set; }
    }
}