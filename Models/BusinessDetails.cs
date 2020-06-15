using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class BusinessDetails
    {
        public BusinessDetails()
        {
            Appointments = new HashSet<Appointments>();
            Services = new HashSet<Services>();
            Timings = new HashSet<Timings>();
            WorkignDays = new HashSet<WorkignDays>();
        }

        public int Business_Id { get; set; }
        public string BusinessToken { get; set; }
        public string Business_Name { get; set; }
        public string Business_Type { get; set; }
        public string Address { get; set; }
        public int Contact_Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Services> Services { get; set; }
        public virtual ICollection<Timings> Timings { get; set; }
        public virtual ICollection<WorkignDays> WorkignDays { get; set; }
    }
}
