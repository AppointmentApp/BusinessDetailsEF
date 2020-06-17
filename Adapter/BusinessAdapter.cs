using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using BusinessDetailsEF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Adapter
{
    public class BusinessAdapter:IBusinessAdapterInterface
    {
        private IBusinessInterface _businessService;
        // BusinessService _businessService = new BusinessService();
        public BusinessAdapter(IBusinessInterface businessService) 
        {
            _businessService = businessService;
        }
        public List<BusinessEntity> getallbusiness()
        {
            var business = _businessService.getall();
            return business;
        }
        public List<BusinessEntity> getallbusinessbytoken(string btoken)
        {
            var business = _businessService.getbytoken(btoken);
            return business;
        }
        public BusinessDetails addbusiness(BusinessEntity businessEntity)
        {
            var business = _businessService.addbusiness(businessEntity);
            return business;
        }
        public BusinessDetails updatebusiness(BusinessEntity businessEntity,string btoken)
        {
            var business = _businessService.updatebusiness(businessEntity,btoken);
            return business;
        }
        public BusinessDetails deletebusiness( string btoken)
        {
            var business = _businessService.deletebusiness( btoken);
            return business;
        }

    }
}
