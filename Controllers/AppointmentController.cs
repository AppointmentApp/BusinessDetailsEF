using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDetailsEF.Controllers
{ 
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentsAdapterInterface _appointmentAdapter;

        public AppointmentController(IAppointmentsAdapterInterface appointmentAdapter)
        {
            _appointmentAdapter = appointmentAdapter;
        }
       
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> findall() 
        {
            try
            {
                var appointments = _appointmentAdapter.getallappointments();
          
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
                var appointments = _appointmentAdapter.getallappointmentbyid(id);
     
                return Ok(appointments);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("addappointment")]
        public async Task<IActionResult> addappointment([FromBody] AppointmentsEntity appointments)
        {
            try
            {
                var appoints = _appointmentAdapter.addappointments(appointments);
              
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
                var ad = _appointmentAdapter.updatestatus(appentity, id);
     
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
                var appointment = _appointmentAdapter.deleteappointment(id);
                
                return Ok(appointment);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}