using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class WorkignDays
    {
        public int workId { get; set; }
        public int? Business_Id { get; set; }
        public int? dayid { get; set; }

        public virtual BusinessDetails Business_ { get; set; }
        public virtual Days day { get; set; }
    }
}
