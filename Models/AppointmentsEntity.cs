using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Models
{
    public class AppointmentsEntity
    {
        public int AappointmentId { get; set; }
        public string AName { get; set; }
        public int? ABusiness_Id { get; set; }
        public string Aaddress { get; set; }
        public DateTime?Adate1 { get; set; }
        public string AtimeSlot { get; set; }
        public string AContact { get; set; }
        public string Astatus { get; set; }
    }
}
