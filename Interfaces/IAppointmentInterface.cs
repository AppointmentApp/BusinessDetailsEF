using BusinessDetailsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Interfaces
{
    public interface IAppointmentInterface
    {
        List<AppointmentsEntity> getall();
        List<AppointmentsEntity> getbyid(int id);
        Appointments addappointments(AppointmentsEntity appointmentsEntity);
        Appointments updatestatus(AppointmentsEntity appentity, int id);
        Appointments deleteappointment(int id);
    }
}
