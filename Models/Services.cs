using System;
using System.Collections.Generic;

namespace BusinessDetailsEF.Models
{
    public partial class Services
    {
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public int? Business_Id { get; set; }

        public virtual BusinessDetails Business_ { get; set; }
    }
}
