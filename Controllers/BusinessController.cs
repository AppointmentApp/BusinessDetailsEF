using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDetailsEF.Controllers
{
    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
       private IBusinessAdapterInterface _businessAdapter;
        //private appointo146updateContext db = new appointo146updateContext();
        // BusinessAdapter _businessAdapter = new BusinessAdapter();
       public  BusinessController(IBusinessAdapterInterface businessAdapter) 
        {
            _businessAdapter = businessAdapter;
        }
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> findall() 
        {
            try
            {
                var business = _businessAdapter.getallbusiness();
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
                var business = _businessAdapter.getallbusinessbytoken(btoken);
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
                var business = _businessAdapter.addbusiness(businessEntity);
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
            try
            {
                var bd = _businessAdapter.updatebusiness(businessEntity,btoken);
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
                var business = _businessAdapter.deletebusiness(btoken);
                return Ok(business);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}