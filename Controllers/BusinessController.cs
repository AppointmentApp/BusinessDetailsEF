using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDetailsEF.Controllers
{
    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        //private appointo146updateContext db = new appointo146updateContext();
        BusinessAdapter businessAdapter = new BusinessAdapter();
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> findall() 
        {
            try
            {
                var business = businessAdapter.getallbusiness();
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
                var business = businessAdapter.getallbusinessbytoken(btoken);
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
                var business = businessAdapter.addbusiness(businessEntity);
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
                var bd = businessAdapter.updatebusiness(businessEntity,btoken);
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
                var business = businessAdapter.deletebusiness(btoken);
                return Ok(business);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}