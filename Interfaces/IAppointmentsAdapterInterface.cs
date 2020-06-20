using BusinessDetailsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Interfaces
{
    public interface IAppointmentsAdapterInterface
    {
        List<AppointmentsEntity> getallappointments();
        List<AppointmentsEntity> getallappointmentbyid(int id);
        List<AppointmentsEntity> getallappointmentbybid(string token);
        Appointments addappointments(AppointmentsEntity appointmentsEntity);
        Appointments updatestatus(AppointmentsEntity appointmentEntity, int id);
        Appointments deleteappointment(int id);
    }
}
