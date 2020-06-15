using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class Days
    {
        public Days()
        {
            WorkignDays = new HashSet<WorkignDays>();
        }

        public int dayId { get; set; }
        public string dayName { get; set; }

        public virtual ICollection<WorkignDays> WorkignDays { get; set; }
    }
}
