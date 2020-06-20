using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using BusinessDetailsEF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Adapter
{
    public class AppointmentsAdapter:IAppointmentsAdapterInterface
    {
        //AppointmentsService _appointmentService = new AppointmentsService();
        private IAppointmentInterface _appointmentService;
      
        public AppointmentsAdapter(IAppointmentInterface appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public List<AppointmentsEntity> getallappointments()
        {
            var appointments = _appointmentService.getall();
            return appointments;
        }
        public List<AppointmentsEntity> getallappointmentbyid(int id)
        {
            var appointments = _appointmentService.getbyid(id);
            return appointments;
        }

        public List<AppointmentsEntity> getallappointmentbybid(string token,DateTime dateTime)
        {
            AppointmentsEntity appointmentsEntity = new AppointmentsEntity();
            List<AppointmentsEntity>  appointmentlist=new List<AppointmentsEntity>();
            var appointments = _appointmentService.getbybid(token);
            foreach (var item in appointments)
            {
                if (item.Adate1 == dateTime)
                {
                    appointmentsEntity.Aaddress = item.Aaddress;
                    appointmentsEntity.AappointmentId = item.AappointmentId;
                    appointmentsEntity.ABusiness_Id = item.ABusiness_Id;
                    appointmentsEntity.AContact = item.AContact;
                    appointmentsEntity.Adate1 = item.Adate1;
                    appointmentsEntity.AName = item.AName;
                    appointmentsEntity.Astatus = item.Astatus;
                    appointmentsEntity.AtimeSlot = item.AtimeSlot;
                }
                else 
                {
                    Console.WriteLine("Date Not found!");
                }
            }appointmentlist.Add(appointmentsEntity);
            return appointments;
        }
            public Appointments addappointments(AppointmentsEntity appointmentsEntity)
        {
            var appointments = _appointmentService.addappointments(appointmentsEntity);
            return appointments;
        }
        public Appointments updatestatus(AppointmentsEntity appointmentEntity, int id)
        {
            var appointments = _appointmentService.updatestatus(appointmentEntity, id);
            return appointments;
        }
        public Appointments deleteappointment(int id)
        {
            var appointments = _appointmentService.deleteappointment(id);
            return appointments;
        }

        public List<AppointmentsEntity> getallappointmentbybid(string token)
        {
            var appointments = _appointmentService.getbybid(token);
            return appointments;
        }
    }
}
