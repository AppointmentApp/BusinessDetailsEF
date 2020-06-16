using BusinessDetailsEF.Models;
using BusinessDetailsEF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Adapter
{
    public class AppointmentsAdapter
    {
        AppointmentsService appointmentService = new AppointmentsService();
        public List<AppointmentsEntity> getallappointments()
        {
            var appointments = appointmentService.getall();
            return appointments;
        }
        public List<AppointmentsEntity> getallappointmentbyid(int id)
        {
            var appointments = appointmentService.getbyid(id);
            return appointments;
        }
        public Appointments addappointments(AppointmentsEntity appointmentsEntity)
        {
            var appointments = appointmentService.addappointments(appointmentsEntity);
            return appointments;
        }
        public Appointments updatestatus(AppointmentsEntity appointmentEntity, int id)
        {
            var appointments = appointmentService.updatestatus(appointmentEntity, id);
            return appointments;
        }
        public Appointments deleteappointment(int id)
        {
            var appointments = appointmentService.deleteappointment(id);
            return appointments;
        }

    }
}
