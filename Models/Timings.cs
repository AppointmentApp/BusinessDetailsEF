using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class Timings
    {
        public int timeId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int? Business_id { get; set; }

        public virtual BusinessDetails Business_ { get; set; }
    }
}
