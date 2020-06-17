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

    }
}
