using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Service
{
    public class BusinessService:IBusinessInterface
    {
        private appointo146updateContext db = new appointo146updateContext();
        public BusinessService() { }
        public string Generateguid() 
        {
            var token = Guid.NewGuid().ToString();
            //Guid guid = new Guid();
            //var token = guid.ToString();
            return token;
        }
        public List<BusinessEntity> getall() 
        {
            
            var business = db.BusinessDetails.Select(p => new BusinessEntity()
            {
                bid = p.Business_Id,
                btoken = p.BusinessToken,
                bname = p.Business_Name,
                btype = p.Business_Type,
                baddress = p.Address,
                bcontactNumber = p.Contact_Number,
                bcity = p.City,
                bstate = p.State
            }).ToList();
            return (business);
        }
        public List<BusinessEntity> getbytoken(string btoken) {
            var business = db.BusinessDetails.Where(p => p.BusinessToken == btoken).Select(p => new BusinessEntity()
            {

                btoken = p.BusinessToken,
                bname = p.Business_Name,
                btype = p.Business_Type,
                baddress = p.Address,
                bcontactNumber = p.Contact_Number,
                bcity = p.City,
                bstate = p.State
            }).ToList();
            return (business);
        }

        public BusinessDetails  addbusiness(BusinessEntity businessEntity)
        {
            var business = new BusinessDetails()
            {
                BusinessToken = Generateguid(),
            Business_Name = businessEntity.bname,
                Business_Type = businessEntity.btype,   
                Address = businessEntity.baddress,
                Contact_Number = businessEntity.bcontactNumber,
                City = businessEntity.bcity,
                State = businessEntity.bstate
            };
            db.BusinessDetails.Add(business);
            db.SaveChanges();
            return (business);
        }
        public BusinessDetails updatebusiness(BusinessEntity businessEntity, string btoken)
        {
            var bd = db.BusinessDetails.FirstOrDefault(item => item.BusinessToken == btoken);
            if (bd != null)
            {
                bd.Business_Name = businessEntity.bname;
                bd.Business_Type = businessEntity.btype;
                bd.Address = businessEntity.baddress;
                bd.Contact_Number = businessEntity.bcontactNumber;
                bd.City = businessEntity.bcity;
                bd.State = businessEntity.bstate;
            }
            db.BusinessDetails.Update(bd);
            db.SaveChanges();
            return (bd);
        }
        public BusinessDetails deletebusiness(string btoken) 
        {
            var business = db.BusinessDetails.FirstOrDefault(item => item.BusinessToken == btoken); 
            db.BusinessDetails.Remove(business);
            db.SaveChanges();
            return (business);
        }
    }
}
        