using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Models
{
    public class BusinessEntity
    {
        public int bid { get; set; }
        public string btoken { get; set; }
        public string bname { get; set; }
        public string btype { get; set; }
        public string baddress { get; set; }
        public int bcontactNumber { get; set; }
        public string bcity { get; set; }
        public string bstate { get; set; }
    }
}
