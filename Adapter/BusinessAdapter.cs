using BusinessDetailsEF.Models;
using BusinessDetailsEF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Adapter
{
    public class BusinessAdapter
    {
        BusinessService businessService = new BusinessService();
        public List<BusinessEntity> getallbusiness()
        {
            var business = businessService.getall();
            return business;
        }
        public List<BusinessEntity> getallbusinessbytoken(string btoken)
        {
            var business = businessService.getbytoken(btoken);
            return business;
        }
        public BusinessDetails addbusiness(BusinessEntity businessEntity)
        {
            var business = businessService.addbusiness(businessEntity);
            return business;
        }
        public BusinessDetails updatebusiness(BusinessEntity businessEntity,string btoken)
        {
            var business = businessService.updatebusiness(businessEntity,btoken);
            return business;
        }
        public BusinessDetails deletebusiness( string btoken)
        {
            var business = businessService.deletebusiness( btoken);
            return business;
        }

    }
}
