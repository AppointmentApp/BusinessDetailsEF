using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class Appointments
    {
        public int appointmentId { get; set; }
        public string Name { get; set; }
        public int? Business_Id { get; set; }
        public string address { get; set; }
        public DateTime? date1 { get; set; }
        public string timeSlot { get; set; }
        public string Contact { get; set; }
        public string status { get; set; }

        public virtual BusinessDetails Business_ { get; set; }
    }
}
