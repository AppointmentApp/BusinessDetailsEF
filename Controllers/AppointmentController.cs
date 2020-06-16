using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDetailsEF.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentsAdapter appAdapter = new AppointmentsAdapter();
      
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> findall() 
        {
            try
            {
                var appointments = appAdapter.getallappointments();
          
                return Ok(appointments);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findbyappointmentid/{id}")]
        public async Task<IActionResult> findbyappointmentid(int id)
        {
            try
            {
                var appointments = appAdapter.getallappointmentbyid(id);
     
                return Ok(appointments);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("addbusiness")]
        public async Task<IActionResult> addappointment([FromBody] AppointmentsEntity appointments)
        {
            try
            {
                var appoints = appAdapter.addappointments(appointments);
              
                return Ok(appoints);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("updatestatus/{id}")]
        public async Task<IActionResult> updatestatus([FromBody] AppointmentsEntity appentity, int id)
        {
           
            //var ad = auc.Appointments.FirstOrDefault(item => item.appointmentId == id);
            try
            {
                var ad = appAdapter.updatestatus(appentity, id);
     
                return Ok(ad);
            }
            catch 
            {
                return BadRequest();
            }
         }
                
        

        [HttpDelete("deleteappointment/{id}")]
        public async Task<IActionResult> deleteappointment(int id)
        {
            try
            {
                var appointment = appAdapter.deleteappointment(id);
                
                return Ok(appointment);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}