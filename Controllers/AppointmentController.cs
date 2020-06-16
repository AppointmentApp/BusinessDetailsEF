using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                //var appointments = auc.Appointments.Select(p => new AppointmentsEntity()
                //{AappointmentId=p.appointmentId,
                //ABusiness_Id=p.Business_Id,
                //AName=p.Name,
                //Aaddress=p.address,
                //Adate1=p.date1,
                //AtimeSlot=p.timeSlot,
                //AContact=p.Contact,
                //Astatus=p.status
                //}).ToList();
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
                //var appointments = auc.Appointments.Where(p=>p.appointmentId==id).Select(p => new AppointmentsEntity()
                //{

                //    AName = p.Name,
                //    Aaddress = p.address,
                //    Adate1 = p.date1,
                //    AtimeSlot = p.timeSlot,
                //   AContact = p.Contact,
                //    Astatus = p.status
                //}).ToList();
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
                //var appoints = new Appointments()
                //{
                //    Name = appointments.AName,
                //    address = appointments.Aaddress,
                //    date1 = appointments.Adate1,
                //    timeSlot = appointments.AtimeSlot,
                //    Contact = appointments.AContact,
                //    status = appointments.Astatus
                //};
                //auc.Appointments.Add(appoints);
                //auc.SaveChanges();
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
                //    if (ad != null)
                //    {

                //        ad.status = appentity.Astatus;
                //    }
                //    auc.Appointments.Update(ad);
                //    auc.SaveChanges();
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
                //var appointment = auc.Appointments.Find(id);
                //auc.Appointments.Remove(appointment);
                //auc.SaveChanges();
                return Ok(appointment);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}