using BusinessDetailsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Interfaces
{
    public interface IBusinessAdapterInterface
    {
        List<BusinessEntity> getallbusiness();
        List<BusinessEntity> getallbusinessbytoken(string btoken);
        BusinessDetails addbusiness(BusinessEntity businessEntity);
        BusinessDetails updatebusiness(BusinessEntity businessEntity, string btoken);
        BusinessDetails deletebusiness(string btoken);
       int getbid(string btoken);
    }
}
