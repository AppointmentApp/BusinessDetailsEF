using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BusinessDetailsEF.Controllers
{
    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private appointo146updateContext db = new appointo146updateContext();
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> findall() 
        {
            try
            {
                var business = db.BusinessDetails.Select(p => new BusinessEntity()
                {
                   bid=p.Business_Id,
                    btoken = p.BusinessToken,
                    bname = p.Business_Name,
                   btype = p.Business_Type,
                    baddress = p.Address,
                    bcontactNumber= p.Contact_Number,
                    bcity = p.City,
                    bstate = p.State
                }).ToList();
                return Ok(business);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findbytoken/{btoken}")]
        public async Task<IActionResult> findbyToken(string btoken)
        {
            try
            {
                var business = db.BusinessDetails.Where(p=>p.BusinessToken==btoken).Select(p => new BusinessEntity()
                {
                   
                    btoken = p.BusinessToken,
                    bname = p.Business_Name,
                    btype = p.Business_Type,
                    baddress = p.Address,
                    bcontactNumber = p.Contact_Number,
                    bcity = p.City,
                    bstate = p.State
                }).ToList();
                return Ok(business);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("addbusiness")]
        public async Task<IActionResult> addbusiness([FromBody] BusinessEntity businessEntity)
        {
            try
            {
                var business = new BusinessDetails()
                {
                    BusinessToken = businessEntity.btoken,
                    Business_Name = businessEntity.bname,
                    Business_Type = businessEntity.btype,
                    Address = businessEntity.baddress,
                    Contact_Number = businessEntity.bcontactNumber,
                    City = businessEntity.bcity,
                    State = businessEntity.bstate
                };
                db.BusinessDetails.Add(business);
                db.SaveChanges();
                return Ok(business);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("updatebusiness/{btoken}")]
        public async Task<IActionResult> updatebusiness([FromBody] BusinessEntity businessEntity, string btoken)
        {
            var bd = db.BusinessDetails.FirstOrDefault(item => item.BusinessToken == btoken);
            try
            {
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
                return Ok(bd);
            }
            catch 
            {
                return BadRequest();
            }
         }
                
        

        [HttpDelete("deletebusiness/{btoken}")]
        public async Task<IActionResult> deletebusiness(string btoken)
        {
            try
            {
                var business = db.BusinessDetails.Find(btoken);
                db.BusinessDetails.Remove(business);
                db.SaveChanges();
                return Ok(business);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}